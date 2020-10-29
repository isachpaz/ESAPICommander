using CommandLine;

namespace ESAPICommander.ArgumentConfig
{
    public class CommonArgOptions
    {
        [Option("dx", Required = false, HelpText = "(Default: as dose grid) Step of sampling in x-axis (mm)")]
        public double Dx_mm { get; set; }

        [Option("dy", Required = false, HelpText = "(Default: as dose grid) Step of sampling in y-axis (mm)")]
        public double Dy_mm { get; set; }

        [Option("dz", Required = false, HelpText = "(Default: as dose grid) Step of sampling in z-axis (mm)")]
        public double Dz_mm { get; set; }

        // Omitting long name, defaults to name of property, ie "--verbose"
        [Option(
            Default = true,
            HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }
    }
}