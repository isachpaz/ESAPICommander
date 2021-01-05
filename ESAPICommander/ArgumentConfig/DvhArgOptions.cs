using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace ESAPICommander.ArgumentConfig
{
    [Verb("dvh", HelpText = "DVH export")]
    public class DvhArgOptions
    {
        //public string PIZ;

        //[Option('o', "dvhfile", Required = true, HelpText = "Output dvh file.")]
        //public string DvhFile { get; set; }

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
                    new Example("Export dose voxels for a list of patients",
                        new DvhArgOptions() {File = "dvh.txt"})
                };
            }
        }
    }
}