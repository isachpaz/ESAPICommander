using System;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Esapi;
using ESAPICommander.Logger;



namespace ESAPICommander.Commands
{
    public class CommandDirectorFactory
    {
        public static BaseCommandDirector CreateDump(DumpArgOptions opts, EsapiManager esapi)
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