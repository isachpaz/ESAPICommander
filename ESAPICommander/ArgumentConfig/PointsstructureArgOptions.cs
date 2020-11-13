using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace ESAPICommander.ArgumentConfig
{
    [Verb("pointsstructure", HelpText = "Export dose matrix voxel points belonging to a structure.")]
    public class PointsstructureArgOptions : CommonArgOptions
    {
        public override string ToString()
        {
            return $"{nameof(PIZ)}: {PIZ}, {nameof(Course)}: {Course}, {nameof(Plan)}: {Plan}, {nameof(Structures)}: {string.Join(", ", Structures)}, {nameof(Verbose)}: {Verbose}";
        }

        [Option('z', "PIZ", Required = true, HelpText = "Patient PIZ number")]
        public string PIZ { get; set; }


        [Option('c', "course", Required = true, HelpText = "Course name")]
        public string Course { get; set; }


        [Option('p', "plan", Required = true, HelpText = "Plan name")]
        public string Plan { get; set; }

        [Option('s', "structures", Required = true, HelpText = "Structure names")]
        public IEnumerable<string> Structures { get; set; }

        [Option('o', "outputfile", Required = false, HelpText = "Write to csv file")]
        public string File { get; set; }

        [Usage(ApplicationAlias = "ESAPICommander")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>()
                {
                    new Example("Export dose voxel points for a structure",
                        new PointsstructureArgOptions {PIZ = "1234567", Structures = new[]{"prostate gland"}, Plan = "plan1", Course = "C1"})
                };
            }
        }
    }
}