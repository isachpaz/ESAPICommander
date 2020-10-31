using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using ESAPICommander.Interfaces;
using ESAPICommander.Proxies;
using Moq;


namespace ESAPICommander.Tests.Proxies
{
    public class NullEclipseProxy : IEsapiCalls
    {
        public void Dispose()
        {

        }

        public bool IsPatientAvailable(string piz)
        {
            return true;
        }

        public void OpenPatient(string piz)
        {

        }

        public void ClosePatient()
        {

        }

        public IEnumerable<Interfaces.ICourse> GetCourses()
        {
            var moq = new Mock<ICourse>();
            moq.Setup(m => m.Id).Returns("C1");
            
            return new ICourse[] {moq.Object, moq.Object};
        }

        public IEnumerable<Interfaces.IPlanSetup> GetPlanSetupsFor(string course)
        {
            var moq = new Mock<ICourse>();
            var moqPlanSetup = new Mock<IPlanSetup>();
            moq.Setup(m => m.Id).Returns("C1");
            moqPlanSetup.Setup(m => m.Id).Returns("Plan-1");
            moq.Setup(m => m.PlanSetups).Returns(new List<IPlanSetup>() {moqPlanSetup.Object});
            return new IPlanSetup[]{moqPlanSetup.Object, moqPlanSetup.Object};
        }

        public IEnumerable<Interfaces.IPlanSum> GetPlanSumsFor(string course)
        {
            var moqPlanSum = new Mock<IPlanSum>();
            moqPlanSum.Setup(m => m.Id).Returns("PlanSum-1");
            return new IPlanSum[] { moqPlanSum.Object };
        }
    }
}