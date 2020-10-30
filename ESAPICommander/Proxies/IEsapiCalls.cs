using System;
using Microsoft.SqlServer.Server;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Proxies
{
    public interface IEsapiCalls : IDisposable
    {
        bool IsPatientAvailable(string piz);
        Patient OpenPatient(string piz);
        void ClosePatient(string piz);
    }
}