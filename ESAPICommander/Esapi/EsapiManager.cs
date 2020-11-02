using System;
using System.Collections.Generic;
using ESAPICommander.Interfaces;

namespace ESAPICommander.Esapi
{
    public class EsapiManager : IDisposable
    {
        public bool IsPatientAvailable(string piz)
        {
            throw new System.NotImplementedException();
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~EsapiManager()
        {
            ReleaseUnmanagedResources();
        }

        public void OpenPatient(string optionsPiz)
        {
            

        }

        public IEnumerable<ICourse> GetCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPlanSetup> GetPlanSetupsFor(string courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPlanSum> GetPlanSumsFor(string courseId)
        {
            throw new NotImplementedException();
        }
    }
}