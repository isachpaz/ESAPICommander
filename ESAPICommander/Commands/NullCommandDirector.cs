using System;
using ESAPICommander.Logger;
using ESAPICommander.Proxies;

namespace ESAPICommander.Commands
{
    public class NullCommandDirector : BaseCommandDirector
    {
        public override int Run()
        {
            //Do nothing!
            Console.WriteLine("An error occurred. Please check the log file.");
            return -1;
        }

        public NullCommandDirector() : base(new NullEclipseProxy(), new NullLog())
        {
        }
    }
}