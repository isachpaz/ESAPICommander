using System;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Logger;
using ESAPICommander.Proxies;

namespace ESAPICommander.Commands
{
    public class CommandDirectorFactory
    {
        public static BaseCommandDirector CreateDump(DumpArgOptions opts)
        {
            try
            {
                return new DumpCommandDirector(opts, EclipseProxy.Create(), new LogConsole());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return new NullCommandDirector();
        }

    }
}