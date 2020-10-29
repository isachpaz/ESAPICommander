using CommandLine;

namespace ESAPICommander.ArgumentConfig
{
    [Verb("dump", HelpText = "Dump patient information.")]
    public class DumpArgOptions
    {
        [Option('z', "PIZ", Required = true, HelpText = "Patient PIZ number")]
        public string PIZ { get; set; }

    }
}