using System;
using System.Linq;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Interfaces;
using ESAPICommander.Logger;
using ESAPIProxy;
using ESAPIProxy.PatientTree;
using ESAPIProxy.TreeGraph;
using ESAPIX.Extensions;
using ESAPIX.Facade.API;


namespace ESAPICommander.Commands
{
    public class DumpCommandDirector : BaseCommandDirector
    {
        private DumpArgOptions _options;

        public DumpCommandDirector(DumpArgOptions options, ESAPIManager esapi, ILog log) : base(esapi, log, options.PIZ)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override void Run()
        {
            if (!IsPIZAvailable(_options.PIZ))
            {
                _log.AddInfo($"Patient with PIZ={_options.PIZ} cannot be found...");
                _log.AddInfo("Process stopped.");
            }
            else
            {
                _log.AddInfo($"Patient with PIZ={_options.PIZ} found.");
            }

            
            var patient = _esapi.GetPatient();
            PatientTree pt = PatientTree.Initialize(patient.Id);

            var courses = _esapi.GetCourses();
            foreach (var course in courses)
            {
                Node courseNode = pt.AddCourseTagInfoByName(course.Id);
                foreach (var ps in _esapi.GetPlansByCourseId(course.Id))
                {
                    var planNode = Node.FromTagInfo(new PlanSetupTagInfo(ps.Id));
                    courseNode.AddChildren(planNode);
                    var ss = ps.GetStructureSet();
                    var ssNode = Node.FromTagInfo(new StructureSetTagInfo(ss.Id));
                    planNode.AddChildren(ssNode);
                    foreach (Structure structure in ss.Structures)
                    {
                        var structureNode = Node.FromTagInfo(new StructureTagInfo(structure.Id));
                        ssNode.AddChildren(structureNode);
                    }
                }
            }

        }

        public override void ProcessRequest()
        {
            _log.AddInfo("ProcessRequest ...");
        }

        public override void PostProcess()
        {
            _log.AddInfo("Postprocess ...");
        }
    }
}