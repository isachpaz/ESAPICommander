using ESAPICommander.ArgumentConfig;
using System;
using CommandLine;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESAPICommander.Commands;
using ESAPIProxy;
using ESAPIX.Common;
using ESAPIX.Facade.API;
using ESAPIX.Interfaces;
using Newtonsoft.Json;
using Application = VMS.TPS.Common.Model.API.Application;

namespace ESAPICommander
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            var spinner = new Spinner(10, 10);

            // Do your work here instead of sleeping...
            //Thread.Sleep(10000);

            

            try
            {
                spinner.Start();
                return CommandLine.Parser.Default
                    .ParseArguments<DumpArgOptions, PointsstructureArgOptions, DvhArgOptions>(args)
                    .MapResult(
                        (PointsstructureArgOptions opts) => RunPointsstructure(opts),
                        (DvhArgOptions opts) => RunDvh(opts),
                        (DumpArgOptions opts) => RunDump(opts),
                        errs => -1
                    );
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return -1;
            }
            finally
            {
                spinner.Stop();
            }
        }

        private static int RunDump(DumpArgOptions opts)
        {
            var esapiManager = ESAPIManager.CreateEsapiThreadDefault(() => Application.CreateApplication());
            try
            {
                
                var ed = CommandDirectorFactory.CreateDump(opts, esapiManager);
                ed.Run();
                ed.Dispose();
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static int RunDvh(DvhArgOptions opts)
        {
            var esapiManager = ESAPIManager.CreateEsapiThreadDefault(() => Application.CreateApplication());
            try
            {

                var ed = CommandDirectorFactory.CreateDVHExporter(opts, esapiManager);
                ed.Run();
                ed.Dispose();
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static int RunPointsstructure(PointsstructureArgOptions opts)
        {
            var esapiManager = ESAPIManager.CreateEsapiThreadDefault(() => Application.CreateApplication());
            try
            {

                var ed = CommandDirectorFactory.CreatePointsStructure(opts, esapiManager);
                ed.Run();
                ed.Dispose();
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}