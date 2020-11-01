using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Commands;
using ESAPICommander.Logger;
using ESAPICommander.Tests.Proxies;
using NUnit.Framework;

namespace ESAPICommander.Tests
{
    [TestFixture]
    public class DumpCommandDirectorTests
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
        public void Test_Run_PlanSetup()
        {
            var options = new DumpArgOptions(){PIZ = "123456Test"};
            var commander = new DumpCommandDirector(options, new NullEclipseProxy(), new LogConsole(DummyConsole));
            var result = commander.Run();
            Console.WriteLine(string.Join("\n", Repository));
            Assert.AreEqual(true, Repository.Any(x => x.Contains("Plan-1")));
            Assert.AreEqual(true, Repository.Any(x => x.Contains("PIZ=123456Test found")));
        }
        
        [Test]
        public void Test_Run_PlanSum()
        {
            var options = new DumpArgOptions(){PIZ = "123456Test"};
            var commander = new DumpCommandDirector(options, new NullEclipseProxy(), new LogConsole(DummyConsole));
            var result = commander.Run();
            Console.WriteLine(string.Join("\n", Repository));
            Assert.AreEqual(true, Repository.Any(x => x.Contains("PlanSum-1")));
            Assert.AreEqual(true, Repository.Any(x => x.Contains("PIZ=123456Test found")));
        }
    }
}