using System;
using ESAPICommander.Proxies;

namespace ESAPICommander.Commands
{
    public class NullCommandDirector : BaseCommandDirector
    {
        public override void Run()
        {
            //Do nothing!
            Console.WriteLine("An error occurred. Please check the log file.");
        }

        public NullCommandDirector() : base(new NullEclipseProxy())
        {
        }
    }
}