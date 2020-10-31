using System;
using System.Collections.Generic;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Commands;
using ESAPICommander.Logger;
using ESAPICommander.Tests.Proxies;
using NUnit.Framework;

namespace ESAPICommander.Tests
{
    [TestFixture]
    public class PointsstructureCommandDirectorTests
    {
        private Action<string> DummyConsole { get; set; }
        private List<string> Repository { get; set; }

        [SetUp]
        public void Init()
        {
            Repository = new List<string>();
            DummyConsole = s => Repository.Add(s);
        }

        [Test]
        public void Test_Run()
        {
            var options = new DumpArgOptions() { PIZ = "123456Test" };
            var commander = new DumpCommandDirector(options, new NullEclipseProxy(), new LogConsole(DummyConsole));
            var result = commander.Run();
            Console.WriteLine(string.Join("\n", Repository));
        }
    }
}