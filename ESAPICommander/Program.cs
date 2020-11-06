
using ESAPICommander.ArgumentConfig;
using System;
using CommandLine;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESAPICommander.Commands;
using ESAPICommander.Esapi;
using ESAPIX.Common;
using ESAPIX.Facade.API;
using ESAPIX.Interfaces;
using Newtonsoft.Json;
using Application = VMS.TPS.Common.Model.API.Application;


namespace ESAPICommander
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            try
            {
                ////StandAloneContext sac = new StandAloneContext(Application.CreateApplication());

                ////var isPatientValid = sac.SetPatient("Prostata_1-IntraObserver");
                ////var pat = sac.Patient;
                ////var isCourseValid = sac.SetCourse(pat.Courses.FirstOrDefault());
                
                
                var app = VMS.TPS.Common.Model.API.Application.CreateApplication();
                ESAPIX.Common.AppComThread.Instance.SetContext(() => app);

                var facade = new ESAPIX.Facade.API.Application(app);
                ESAPIX.Facade.API.Patient patient = facade.OpenPatientById("Prostata_1-IntraObserver");


                //app.SetPatient("Prostata_1-IntraObserver");
                //var c1 = app.Patient.Courses.FirstOrDefault(x => x.Id == "xHypoFocal_III");
                //app.SetCourse(c1, true);


                //var settings = new JsonSerializerSettings
                //{
                //    Error = (se, ev) => { ev.ErrorContext.Handled = true; }
                //};

                ////Put it into a string
                //var json = JsonConvert.SerializeObject(c1.PlanSetups.FirstOrDefault(), settings);

                //var pat2 = app.Patient;

                //List<Course> courseList = new List<Course>();

                //var service = new ESAPIX.Services.ESAPIService( () => Application.CreateApplication());
                //service.Execute(context => context.SetPatient("123456789"));

                //var pat1 = service.GetValueExp(context => context.Patient);

                //var c1 = app.Patient.Courses.FirstOrDefault(x=>x.Id == "xHypoFocal_III");
                //var ss = app.Patient.StructureSets.FirstOrDefault();

                //var ssOffline = new StructureSet(ss);
                //var structures = ss.Structures.Where(s => s.Id == "GTV-MRI" || s.Id == "GTV-PET").ToList();

                //var sx = ssOffline.AddStructure("AAAA", "BBBBBB");

                //foreach (var structure in structures)
                //{
                //    var snew = ssOffline.AddStructure(structure.DicomType, structure.Id);
                //    snew = new Structure(structure);

                //_ctx.SetCourse(course);


                //}


                return CommandLine.Parser.Default.ParseArguments<DumpArgOptions, PointsstructureArgOptions, DvhArgOptions>(args)
                    .MapResult(
                        (PointsstructureArgOptions opts) => RunPointsstructure(opts),
                        (DvhArgOptions opts) => RunDvh(opts),
                        (DumpArgOptions opts) => RunDump(opts),
                        errs => 1
                     );
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return -1;
            }
        }

        private static int RunDump(DumpArgOptions opts)
        {
            var ed = CommandDirectorFactory.CreateDump(opts, 
                EsapiManager.CreateFromSAC(null));
            var errorCode = ed.Run();
            ed.Dispose();
            return errorCode;
        }

        private static int RunDvh(DvhArgOptions opts)
        {
            throw new NotImplementedException();
        }

        private static int RunPointsstructure(PointsstructureArgOptions opts)
        {
            throw new NotImplementedException();
        }
    }
}
