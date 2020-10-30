
using ESAPICommander.ArgumentConfig;
using System;
using CommandLine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESAPICommander.Commands;

namespace ESAPICommander
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            try
            {
                return CommandLine.Parser.Default.ParseArguments<DumpArgOptions, PointsstructureArgOptions, DvhArgOptions>(args)
                    .MapResult(
                        (PointsstructureArgOptions opts) => RunPointsstructure(opts),
                        (DvhArgOptions opts) => RunDvh(opts),
                        (DumpArgOptions opts) => RunDump(opts),
                        errs => 1
                     );
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
            }

            return -1;
        }

        private static int RunDump(DumpArgOptions opts)
        {
            var ed = CommandDirectorFactory.CreateDump(opts);
            ed.Run();
            ed.Dispose();
            return 0;
        }

        private static int RunDvh(DvhArgOptions opts)
        {
            throw new NotImplementedException();
        }

        private static int RunPointsstructure(PointsstructureArgOptions opts)
        {
            throw new NotImplementedException();
        }
    }
}
