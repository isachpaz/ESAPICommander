using System;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Logger;
using ESAPICommander.Proxies;

namespace ESAPICommander.Commands
{
    public class CommandDirectorFactory
    {
        public static BaseCommandDirector CreateDump(DumpArgOptions opts, IEsapiCalls esapi)
        {
            try
            {
                return new DumpCommandDirector(opts, esapi, new LogConsole());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

    }
}