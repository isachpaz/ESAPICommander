using System;
using System.Linq;
using System.Text;
using System.Windows;
using ESAPIProxy;
using ESAPICommander.Logger;

namespace ESAPICommander.Commands
{
    public abstract class BaseCommandDirector : IDisposable
    {
        protected readonly ESAPIManager _esapi;
        protected readonly ILog _log;
        private readonly string _piz;

        protected BaseCommandDirector(ESAPIManager esapi, ILog log, string piz)
        {
            _esapi = esapi;
            _log = log;
            _piz = piz;
        }


        public void LoadPatientOrThrowException()
        {
            if (!_esapi.OpenPatientbyId(_piz))
            { 
                throw new Exception($"Patient: {_piz} cannot be found.");
            }
            _log.AddInfo($"Patient PIZ={_piz} opened.");
        }

        public virtual void Run()
        {
            try
            {
                LoadPatientOrThrowException();
                ProcessRequest();
                PostProcess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _esapi.Dispose();
            }
            
        }

        public abstract void ProcessRequest();
        public abstract void PostProcess();
        

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