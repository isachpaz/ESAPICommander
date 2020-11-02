using System;
using System.Collections.Generic;
using System.Linq;
using ESAPICommander.Proxies;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace ESAPICommander.Worker
{
    public class ESAPIWorker
    {
        private IEsapiCalls EsapiCalls { get; }

        public ESAPIWorker(IEsapiCalls esapiCalls)
        {
            EsapiCalls = esapiCalls ?? throw new ArgumentNullException(nameof(esapiCalls));
        }

        private static List<VoxelData> ExtractStructurePoints(PlanSum planSum, string[] roiNames)
        {
            List<VoxelData> vc = new List<VoxelData>();

            foreach (PlanSetup plan in planSum.PlanSetups)
            {
                var dose_per_fraction = plan.DosePerFraction;
                var nfx = plan.NumberOfFractions;
                var prescription = dose_per_fraction * nfx;
                plan.DoseValuePresentation = DoseValuePresentation.Absolute;

                List<Structure> structures = GetEStructuresByNameId(roiNames, plan).ToList();

                foreach (Structure structure in structures)
                {
                    var dose = plan.Dose;
                    var sx = Math.Round(dose.XRes, 3);
                    var sy = Math.Round(dose.YRes, 3);
                    var sz = Math.Round(dose.ZRes, 3);

                    var boundingBox = structure.MeshGeometry.Bounds;

                    var contours = structure.MeshGeometry.Positions.Select(e => new VVector(e.X, e.Y, e.Z));

                    //foreach (VVector cp in contours)
                    //{
                    //    var pointDose = dose.GetDoseToPoint(cp);
                    //    VoxelData v = new VoxelData
                    //    {
                    //        PatientId = plan.Course.Patient.Id,
                    //        PatientId2 = plan.Course.Patient.Id2,
                    //        CourseId = plan.Course.Id,
                    //        SumPlanId = planSum.Id,
                    //        PlanId = plan.Id,
                    //        StructureId = structure.Id,
                    //        X = -1,
                    //        Y = -1,
                    //        Z = -1,
                    //        Position = cp,
                    //        DoseToPoint = pointDose,
                    //    };
                    //    vc.Add(v);
                    //}
                    ////  Length  of  individual  dose  profile//
                    var profileSamples = (int) Math.Ceiling(boundingBox.SizeX / dose.XRes);

                    var i_min = (int) Math.Ceiling((boundingBox.X - dose.Origin.x) / sx);
                    var j_min = (int) Math.Ceiling((boundingBox.Y - dose.Origin.y) / sy);
                    var k_min = (int) Math.Ceiling((boundingBox.Z - dose.Origin.z) / sz);

                    var i_max = (int) Math.Ceiling((boundingBox.X + boundingBox.SizeX - dose.Origin.x) / sx);
                    var j_max = (int) Math.Ceiling((boundingBox.Y + boundingBox.SizeY - dose.Origin.y) / sy);
                    var k_max = (int) Math.Ceiling((boundingBox.Z + boundingBox.SizeZ - dose.Origin.z) / sz);

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
                                            PatientId2 = plan.Course.Patient.Id2,
                                            CourseId = plan.Course.Id,
                                            SumPlanId = planSum.Id,
                                            PlanId = plan.Id,
                                            StructureId = structure.Id,
                                            X = x,
                                            Y = y,
                                            Z = z,
                                            Position = dp,
                                            DoseToPoint = voxelDose_1,
                                        };
                                        vc.Add(v);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return vc;
        }

        private static IEnumerable<Structure> GetEStructuresByNameId(string[] roiNames, PlanSetup plan)
        {
            foreach (var roiName in roiNames)
            {
                if (plan.StructureSet.Structures.Any(x => x.Id == roiName))
                {
                    var structure = plan.StructureSet.Structures.First(x => x.Id == roiName);
                    yield return structure;
                }
            }
        }
    }

    public class VoxelData
    {
        public string StructureId { get; set; }
        public VVector Position { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public DoseValue DoseToPoint { get; set; }
        public string PlanId { get; set; }
        public string SumPlanId { get; set; }
        public string PatientId { get; set; }
        public string CourseId { get; set; }
        public string PatientId2 { get; set; }

        public FlatVoxelData GetFlatVoxelData()
        {
            var fd = new FlatVoxelData
            {
                StructureId = this.StructureId,
                DoseInGy = System.Math.Round(this.DoseToPoint.Dose, 6),
                XPos = this.X,
                YPos = this.Y,
                ZPos = this.Z,
                XCor = this.Position.x,
                YCor = this.Position.y,
                ZCor = this.Position.z,
                CourseId = this.CourseId,
                PatientId = this.PatientId,
                PatientId2 = this.PatientId2,
                PlanId = this.PlanId,
                SumPlanId = this.SumPlanId
            };
            return fd;
        }
    }

    public class FlatVoxelData
    {
        public string StructureId { get; set; }
        public double XCor { get; set; }
        public double YCor { get; set; }
        public double ZCor { get; set; }

        public int XPos { get; set; }
        public int YPos { get; set; }
        public int ZPos { get; set; }
        public double DoseInGy { get; set; }
        public string PlanId { get; set; }
        public string SumPlanId { get; set; }
        public string PatientId { get; set; }
        public string CourseId { get; set; }
        public string PatientId2 { get; set; }

    }

}