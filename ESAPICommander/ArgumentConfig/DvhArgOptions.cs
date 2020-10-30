using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace ESAPICommander.ArgumentConfig
{
    [Verb("dvh", HelpText = "DVH export")]
    public class DvhArgOptions
    {
        
        [Option('o', "dvhfile", Required = true, HelpText = "Output dvh file.")]
        public string DvhFile { get; set; }

        [Usage(ApplicationAlias = "ESAPICommander")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>()
                {
                    new Example("Export dose voxels for a list of patients",
                        new DvhArgOptions() {DvhFile = "dvh.txt"})
                };
            }
        }
    }
}