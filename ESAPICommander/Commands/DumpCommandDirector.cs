using System;
using System.Linq;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Interfaces;
using ESAPICommander.Logger;
using ESAPIProxy;
using ESAPIX.Facade.API;


namespace ESAPICommander.Commands
{
    public class DumpCommandDirector : BaseCommandDirector
    {
        private DumpArgOptions _options;

        public DumpCommandDirector(DumpArgOptions options, ESAPIManager esapi, ILog log) : base(esapi, log)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override int Run()
        {
            if (!IsPIZAvailable(_options.PIZ))
            {
                _log.AddInfo($"Patient with PIZ={_options.PIZ} cannot be found...");
                _log.AddInfo("Process stopped.");
                return -1;
            }
            else
            {
                _log.AddInfo($"Patient with PIZ={_options.PIZ} found.");
            }

            _esapi.OpenPatientbyId(_options.PIZ);
            var patient = _esapi.GetPatient();
            PatientTree pt = PatientTree.Initialize(patient.Id);

            var courses = _esapi.GetCourses();
            foreach (var course in courses)
            {
                Console.WriteLine($"course:{course.Id}");
                pt.AddNodeFromTagInfo(new CourseTagInfo(course.Id));
                foreach (var ps in _esapi.GetPlansByCourseId(course.Id))
                {
                    Console.WriteLine("\t"+ps.Id);   
                }
            }

            return 0;
        }

    }
}