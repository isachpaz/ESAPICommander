using System;
using System.Linq;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Logger;
using ESAPICommander.Proxies;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Commands
{
    public class DumpCommandDirector : BaseCommandDirector
    {
        private DumpArgOptions _options;

        public DumpCommandDirector(DumpArgOptions options, IEsapiCalls esapi, ILog log) : base(esapi, log)
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

            var patient = Esapi.OpenPatient(_options.PIZ);

            foreach (Course course in patient.Courses)
            {
                foreach (PlanSetup plan in course.PlanSetups)
                {
                    _log.AddInfo($"Course: {course.Id}");
                    _log.AddInfo($"Plan: {plan?.Id} -> Number of fractions: {plan?.NumberOfFractions}, " +
                                 $"Prescription dose: {plan?.TotalDose}");
                    _log.AddInfo($"StructureSet: {plan?.StructureSet?.Id}");
                    _log.AddInfo($"Structures: {string.Join(", ", plan?.StructureSet?.Structures ?? Array.Empty<Structure>())}");
                    _log.AddInfo("");
                }

                foreach (PlanSum plan in course.PlanSums)
                {
                    _log.AddInfo($"Course: {course.Id}");
                    _log.AddInfo($"Summed Plan: {plan?.Id} -> {string.Join(", ", plan?.PlanSetups?.Select(x => x.Id) ?? Array.Empty<string>())}");
                    _log.AddInfo($"StructureSet: {plan?.StructureSet?.Id}");
                    _log.AddInfo($"Structures: {string.Join(", ", plan?.StructureSet?.Structures ?? Array.Empty<Structure>())}");
                    _log.AddInfo("");
                }
            }
            
        }

    }
}