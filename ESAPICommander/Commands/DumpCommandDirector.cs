using System;
using System.Diagnostics;
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
        private PatientTree _patientTree;

        public DumpCommandDirector(DumpArgOptions options, ESAPIManager esapi, ILog log) : base(esapi, log, options.PIZ)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

       
        public override void ProcessRequest()
        {
            var patient = _esapi.GetPatient();
            _patientTree = PatientTree.Initialize(patient.Id);

            var courses = _esapi.GetCourses();
            foreach (var course in courses)
            {
                Node courseNode = _patientTree.AddCourseTagInfoByName(course.Id);
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

        public override void PostProcess()
        {
            PrintTreeVisitor printOut = new PrintTreeVisitor();
            _patientTree.GetRoot().Accept(printOut);
            Console.WriteLine(printOut.GetOutput());
        }
    }
}