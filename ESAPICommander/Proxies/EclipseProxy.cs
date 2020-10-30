using System;
using System.Linq;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Proxies
{
    public class EclipseProxy : IEsapiCalls
    {
        private Application _app;

        private EclipseProxy(Application app)
        {
            _app = app;
        }

        public static EclipseProxy Create(Application app=null)
        {
            if (app == null)
            {
                app = Application.CreateApplication();
            }
            return new EclipseProxy(app);
        }

        public bool IsPatientAvailable(string piz)
        {
            return _app.PatientSummaries.Any(x => x.Id == piz);
        }

        public Patient OpenPatient(string piz)
        {
            return _app.OpenPatientById(piz);
        }

        public void ClosePatient(string piz)
        {
            _app.ClosePatient();
        }

        public void Dispose()
        {
            _app?.Dispose();
        }
    }
}