using System;
using System.Collections.Generic;
using System.Linq;
using ESAPICommander.Logger;
using NUnit.Framework;

namespace ESAPICommander.Tests
{
    [TestFixture]
    public class LoggerTests
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
        public void Test_LogConsole_AddInfo()
        {
            ILog logger = new LogConsole(DummyConsole);
            logger.AddInfo("Application started");

            Assert.AreEqual(Repository.Any(), true);
            Assert.AreEqual(Repository[0], "Application started");
        }
    }
}