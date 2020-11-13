using System;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Logger;
using ESAPIProxy;


namespace ESAPICommander.Commands
{
    public class CommandDirectorFactory
    {
        public static BaseCommandDirector CreateDump(DumpArgOptions opts, ESAPIManager esapi)
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

        public static BaseCommandDirector CreatePointsStructure(PointsstructureArgOptions opts, ESAPIManager esapi)
        {
            try
            {
                return new PointsstructureCommandDirector(opts, esapi, new LogConsole());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public static BaseCommandDirector CreateDVHExporter(DvhArgOptions opts, ESAPIManager esapi)
        {
            try
            {
                return new DvhCommandDirector(opts, esapi, new LogConsole());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

    }
}