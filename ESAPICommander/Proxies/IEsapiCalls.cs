using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using VMS.TPS.Common.Model;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Proxies
{
    public interface IEsapiCalls : IDisposable
    {
        bool IsPatientAvailable(string piz);
        void OpenPatient(string piz);
        void ClosePatient();
        IEnumerable<ICourse> GetCourses();
        IEnumerable<IPlanSetup> GetPlanSetupsFor(ICourse course);
    }
}