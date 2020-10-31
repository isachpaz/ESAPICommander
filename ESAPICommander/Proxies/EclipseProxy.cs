using System;
using System.Collections.Generic;
using System.Linq;
using VMS.TPS.Common.Model;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Proxies
{
    public class EclipseProxy : IEsapiCalls
    {
        private Application _app;
        private Patient _patient;

        private EclipseProxy(Application app)
        {
            _app = app;
        }

        public static IEsapiCalls Create(Application app=null)
        {
            try
            {
                if (app == null)
                {
                    app = Application.CreateApplication();
                }
                return new EclipseProxy(app);
            }
            catch (Exception e)
            {   
                return new NullEclipseProxy();
            }
        }

        public bool IsPatientAvailable(string piz)
        {
            return _app.PatientSummaries.Any(x => x.Id == piz);
        }

        public void OpenPatient(string piz)
        {
            _patient = _app.OpenPatientById(piz);
        }

        public void ClosePatient()
        {
            _app.ClosePatient();
        }

        public IEnumerable<ICourse> GetCourses()
        {
            if (_patient != null)
            {
                return _patient.Courses.Select(x=>(ICourse)x);
            }
            return new List<ICourse>();
        }

        public IEnumerable<IPlanSetup> GetPlanSetupsFor(ICourse course)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _app?.Dispose();
        }
    }
}