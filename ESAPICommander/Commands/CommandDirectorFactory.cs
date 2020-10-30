using System;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Proxies;

namespace ESAPICommander.Commands
{
    public class CommandDirectorFactory
    {
        public static BaseCommandDirector CreateDump(DumpArgOptions opts)
        {
            try
            {
                return new DumpCommandDirector(opts, EclipseProxy.Create());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return new NullCommandDirector();
        }

    }
}