using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.Types;
using EC = ESAPIX.Common;
using E = ESAPIX.Facade.API;
using V = VMS.TPS.Common.Model.API;

namespace ESAPIProxy
{
    public class ESAPIManager : IDisposable
    {
        private readonly EC.AppComThread _thread;

        protected ESAPIManager(EC.AppComThread _thread)
        {
            this._thread = _thread;
        }

        public static ESAPIManager CreateEsapiThreadDefault(Func<V.Application> createAppFunc)
        {
            ESAPIX.Common.AppComThread.Instance.SetContext(createAppFunc);
            return new ESAPIManager(ESAPIX.Common.AppComThread.Instance);
        }

        public E.User GetUser()
        {
            return _thread.GetValue(ctx =>
            {
                var user = new ESAPIX.Facade.API.User {Name = ctx.CurrentUser.Name, Id = ctx.CurrentUser.Id};
                return user;
            });
        }

        public bool OpenPatientbyId(string zip)
        {
            return _thread.GetValue(ctx =>
            {
                var result = ctx.SetPatient(zip);
                return result;
            });
        }

        public E.Patient GetPatient()
        {
            return _thread.GetValue(ctx =>
            {
                var patient = new E.Patient()
                {
                    Name = ctx.Patient.Name,
                    Id = ctx.Patient.Id,
                };
                return patient;
            });
        }

        public E.Patient GetPatientX()
        {
            return _thread.GetValue(ctx =>
            {
                var patient = new E.Patient(ctx.Patient);
                return patient;
            });
        }

        public IEnumerable<E.PatientSummary> GetPatientSummaries()
        {
            return _thread.GetValue(ctx =>
            {
                var summaries = ctx.Application.PatientSummaries;
                List<E.PatientSummary> list = new List<E.PatientSummary>();
                foreach (V.PatientSummary item in summaries)
                {
                    var ps = new E.PatientSummary
                    {
                        FirstName = item.FirstName, LastName = item.LastName, Id = item.Id
                    };
                    list.Add(ps);
                }

                return list;
            });
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                _thread?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ESAPIManager()
        {
            Dispose(false);
        }

        public List<E.Course> GetCourses()
        {
            var courseNames = _thread.GetValue(ctx =>
            {
                var courses = ctx.Patient?.Courses;
                List<E.Course> xCourses = new List<E.Course>();
                foreach (V.Course item in courses)
                {
                    dynamic mc = new E.Course(item);
                    xCourses.Add(mc);
                }

                return xCourses;
            });

            return courseNames;
        }

        public IEnumerable<E.PlanSetup> GetPlansByCourseId(string courseId)
        {
            return _thread.GetValue(ctx =>
            {
                var courses = ctx.Patient?.Courses.Where(c => c.Id == courseId);
                var xPlans = new List<E.PlanSetup>();
                foreach (var course in courses)
                {
                    foreach (var item in course.PlanSetups)
                    {
                        var xPlan = new E.PlanSetup(item);
                        xPlans.Add(xPlan);
                    }
                }

                return xPlans;
            });
        }

        private List<V.Structure> GetStructuresByNames(EC.StandAloneContext sac,
            string[] roiNames,
            string courseId,
            string planSetupId)
        {
            var structures = new List<V.Structure>();
            var courses = sac.Patient.Courses.Where(x => x.Id == courseId);
            foreach (var courseItem in courses)
            {
                var plan = courseItem.PlanSetups.FirstOrDefault(p => p.Id == planSetupId);
                if (!(plan is null))
                {
                    plan.DoseValuePresentation = DoseValuePresentation.Absolute;

                    foreach (var roiName in roiNames)
                    {
                        if (plan.StructureSet.Structures.Any(x => x.Id == roiName))
                        {
                            var structure = plan.StructureSet.Structures.First(x => x.Id == roiName);
                            var geom = structure.MeshGeometry;
                            var bound = geom.Bounds;
                            structures.Add(structure);
                        }
                    }
                }
            }

            return structures;
        }

        public List<VoxelData> ExtractStructurePoints(string courseId,
            string planSetupId,
            string[] roiNames)
        {
            return _thread.GetValue(ctx =>
            {
                List<VoxelData> vc = new List<VoxelData>();
                var courses = ctx.Patient.Courses.Where(x => x.Id == courseId);

                var structures = GetStructuresByNames(ctx, roiNames, courseId, planSetupId);

                foreach (var courseItem in courses)
                {
                    var plan = courseItem.PlanSetups.FirstOrDefault(p => p.Id == planSetupId);
                    plan.DoseValuePresentation = DoseValuePresentation.Absolute;

                    foreach (var structure in structures)
                    {
                        var dose = plan.Dose;
                        var sx = Math.Round(dose.XRes, 3);
                        var sy = Math.Round(dose.YRes, 3);
                        var sz = Math.Round(dose.ZRes, 3);

                        if (structure.MeshGeometry != null)
                        {
                            var boundingBox = structure.MeshGeometry.Bounds;

                            var contours = structure.MeshGeometry.Positions.Select(e => new VVector(e.X, e.Y, e.Z));


                            var profileSamples = (int) Math.Ceiling(boundingBox.SizeX / dose.XRes);

                            var i_min = (int) Math.Ceiling((boundingBox.X - dose.Origin.x) / sx);
                            var j_min = (int) Math.Ceiling((boundingBox.Y - dose.Origin.y) / sy);
                            var k_min = (int) Math.Ceiling((boundingBox.Z - dose.Origin.z) / sz);

                            var i_max = (int) Math.Ceiling((boundingBox.X + boundingBox.SizeX - dose.Origin.x) /
                                                           sx);
                            var j_max = (int) Math.Ceiling((boundingBox.Y + boundingBox.SizeY - dose.Origin.y) /
                                                           sy);
                            var k_max = (int) Math.Ceiling((boundingBox.Z + boundingBox.SizeZ - dose.Origin.z) /
                                                           sz);

                            //var offset = sx / 2.0;

                            var scale = dose.VoxelToDoseValue(1).Dose - dose.VoxelToDoseValue(0).Dose;
                            var offset = dose.VoxelToDoseValue(0).Dose / scale;

                            int[,] buffer = new int[dose.XSize, dose.YSize];
                            if (dose != null)
                            {
                                for (int z = k_min; z <= k_max; z++)
                                {
                                    dose.GetVoxels(z, buffer);
                                    for (int y = j_min; y <= j_max; y++)
                                    {
                                        for (int x = i_min; x <= i_max; x++)
                                        {
                                            int value = buffer[x, y];

                                            double xi = dose.Origin.x + (x * sx);
                                            double yi = dose.Origin.y + (y * sy);
                                            double zi = dose.Origin.z + (z * sz);
                                            VVector dp = new VVector(xi, yi, zi);

                                            //var structuresWithPoint = GetStructuresWherePointIsInside(structures, dp);
                                            Boolean b = structure.IsPointInsideSegment(dp);
                                            if (b)
                                            {
                                                var voxelDose_1 = dose.VoxelToDoseValue(value);
                                                //var vd_1 = voxelDose_1.Dose;

                                                //var doseAt = dose.GetDoseToPoint(dp);
                                                //Console.WriteLine($" {structure.StructureId} -> ({x}, {y}, {z}) {voxelDose_1}");


                                                //Trace.WriteLine(b);
                                                VoxelData v = new VoxelData
                                                {
                                                    PatientId = plan.Course.Patient.Id,
                                                    CourseId = plan.Course.Id,
                                                    PlanId = plan.Id,
                                                    StructureId = structure.Id,
                                                    I = x,
                                                    J = y,
                                                    K = z,
                                                    Position = dp,
                                                    DoseToPoint = voxelDose_1,
                                                    OriginX = plan.Dose.Origin.x,
                                                    OriginY = plan.Dose.Origin.y,
                                                    OriginZ = plan.Dose.Origin.z,
                                                    XRes = plan.Dose.XRes,
                                                    YRes = plan.Dose.XRes,
                                                    ZRes = plan.Dose.XRes,
                                                    XDirection = plan.Dose.XDirection,
                                                    YDirection = plan.Dose.YDirection,
                                                    ZDirection = plan.Dose.ZDirection,
                                                };
                                                vc.Add(v);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return vc;
            });
        }

        public List<string> ExtractDVHs(string courseId,
            string planSetupId,
            string[] roiNames)
        {
            return _thread.GetValue(ctx =>
            {
                var courses = ctx.Patient.Courses.Where(x => x.Id == courseId);
                var structures = GetStructuresByNames(ctx, roiNames, courseId, planSetupId);

                foreach (var courseItem in courses)
                {
                    var plan = courseItem.PlanSetups.FirstOrDefault(p => p.Id == planSetupId);
                    plan.DoseValuePresentation = DoseValuePresentation.Absolute;

                    foreach (var structure in structures)
                    {
                    }
                }

                return new List<string>();
            });
        }
    }
}