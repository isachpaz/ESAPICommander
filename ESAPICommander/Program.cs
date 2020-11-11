﻿
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
        private static ESAPIManager _esapiManager;

        //[STAThread]
        static int Main(string[] args)
        {
            try
            {
                var app = VMS.TPS.Common.Model.API.Application.CreateApplication();
                _esapiManager = ESAPIManager.CreateEsapiThreadDefault(()=>app);

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
                return -1;
            }
        }

        private static int RunDump(DumpArgOptions opts)
        {
            var ed = CommandDirectorFactory.CreateDump(opts, _esapiManager);
            var errorCode = ed.Run();
            ed.Dispose();
            return errorCode;
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
