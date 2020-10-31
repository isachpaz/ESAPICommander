using System;
using System.Collections.Generic;
using System.Linq;
using ESAPICommander.Adapters;
using ESAPICommander.Interfaces;
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

        public static IEsapiCalls Create(Application app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            return new EclipseProxy(app);
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
            EclipseProxy.CheckPatientOrThrowException(_patient);
            return _patient.Courses.Select(x=>new CourseAdapter(x));
        }

        public IEnumerable<IPlanSetup> GetPlanSetupsFor(string courseId)
        {
            EclipseProxy.CheckPatientOrThrowException(_patient);
            var course = _patient.Courses.FirstOrDefault(x => x.Id == courseId);
            return course?.PlanSetups.Select(x => (new PlanSetupAdapter(x)) as IPlanSetup);
        }

        private static void CheckPatientOrThrowException(Patient patient)
        {
            if (patient == null)
                throw new Exception("Patient is not opened.");
        }

        public IEnumerable<IPlanSum> GetPlanSumsFor(string courseId)
        {
            EclipseProxy.CheckPatientOrThrowException(_patient);
            var course = _patient.Courses.FirstOrDefault(x => x.Id == courseId);
            return course?.PlanSums.Select(x => (new PlanSumAdapter(x)) as IPlanSum);
        }

        public void Dispose()
        {
            _app?.Dispose();
        }
    }
}