using System;
using System.Linq;
using ESAPIProxy;
using ESAPICommander.Logger;

namespace ESAPICommander.Commands
{
    public abstract class BaseCommandDirector : IDisposable
    {
        protected readonly ESAPIManager _esapi;
        protected readonly ILog _log;

        protected BaseCommandDirector(ESAPIManager esapi, ILog log)
        {
            _esapi = esapi;
            _log = log;
        }

        

        public abstract int Run();

        public bool IsPIZAvailable(string piz)
        {
            return _esapi.GetPatientSummaries().Any(p=>p.Id == piz);
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
                _esapi.Dispose();
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