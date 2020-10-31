using System;
using System.Linq;
using ESAPICommander.Logger;
using ESAPICommander.Proxies;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Commands
{
    public abstract class BaseCommandDirector : IDisposable
    {
        protected readonly ILog _log;

        protected BaseCommandDirector(IEsapiCalls esapi, ILog log)
        {
            _log = log;
            Esapi = esapi;
        }

        protected  IEsapiCalls Esapi { get; set; }

        public abstract int Run();

        public bool IsPIZAvailable(string piz)
        {
            return Esapi.IsPatientAvailable(piz);
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        protected virtual void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                Esapi.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseCommandDirector()
        {
            Dispose(false);
        }
    }
}