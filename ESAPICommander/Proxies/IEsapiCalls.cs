using System;
using System.Collections.Generic;
using ESAPICommander.Interfaces;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Proxies
{
    public interface IEsapiCalls : IDisposable
    {
        bool IsPatientAvailable(string piz);
        void OpenPatient(string piz);
        void ClosePatient();
        IEnumerable<ICourse> GetCourses();
        IEnumerable<IPlanSetup> GetPlanSetupsFor(string course);
        IEnumerable<IPlanSum> GetPlanSumsFor(string course);
    }
}