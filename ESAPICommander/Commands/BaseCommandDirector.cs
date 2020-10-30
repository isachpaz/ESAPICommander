using System;
using System.Linq;
using ESAPICommander.Proxies;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Commands
{
    public abstract class BaseCommandDirector : IDisposable
    {
        protected BaseCommandDirector(IEsapiCalls esapi)
        {
            Esapi = esapi;
        }

        protected  IEsapiCalls Esapi { get; set; }

        public abstract void Run();

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