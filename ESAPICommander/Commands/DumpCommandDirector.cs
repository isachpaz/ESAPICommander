using System;
using System.Linq;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Proxies;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Commands
{
    public class DumpCommandDirector : BaseCommandDirector
    {
        private DumpArgOptions _options;

        public DumpCommandDirector(DumpArgOptions options, IEsapiCalls esapi) : base(esapi)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override void Run()
        {
            if (!IsPIZAvailable(_options.PIZ))
            {
                Console.WriteLine($"Patient with PIZ={_options.PIZ} cannot be found...");
                Console.WriteLine("Process stopped.");
            }
            else
            {
                Console.WriteLine($"Patient with PIZ={_options.PIZ} found.");
            }

            var patient = Esapi.OpenPatient(_options.PIZ);

            foreach (Course course in patient.Courses)
            {
                foreach (PlanSetup plan in course.PlanSetups)
                {
                    Console.WriteLine($"Course: {course.Id}");
                    Console.WriteLine($"Plan: {plan?.Id} -> Number of fractions: {plan?.NumberOfFractions}, " +
                                      $"Prescription dose: {plan?.TotalDose}");
                    Console.WriteLine($"StructureSet: {plan?.StructureSet?.Id}");
                    Console.WriteLine($"Structures: {string.Join(", ", plan?.StructureSet?.Structures ?? Array.Empty<Structure>())}");
                    Console.WriteLine("");
                }

                foreach (PlanSum plan in course.PlanSums)
                {
                    Console.WriteLine($"Course: {course.Id}");
                    Console.WriteLine($"Summed Plan: {plan?.Id} -> {string.Join(", ", plan?.PlanSetups?.Select(x => x.Id) ?? Array.Empty<string>())}");
                    Console.WriteLine($"StructureSet: {plan?.StructureSet?.Id}");
                    Console.WriteLine($"Structures: {string.Join(", ", plan?.StructureSet?.Structures ?? Array.Empty<Structure>())}");
                    Console.WriteLine("");
                }
            }
            
        }

    }
}