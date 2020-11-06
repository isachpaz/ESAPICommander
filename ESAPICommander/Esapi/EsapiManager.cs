using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESAPICommander.Interfaces;
using ESAPIX.Common;
using E = ESAPIX.Facade.API;

namespace ESAPICommander.Esapi
{
    public class EsapiManager : IDisposable
    {
        private StandAloneContext _ctx { get; set; }

        private EsapiManager(StandAloneContext ctx)
        {
            _ctx = ctx;
        }

        public static EsapiManager CreateFromSAC(StandAloneContext ctx)
        {
            return new EsapiManager(ctx);
        }

        public bool OpenPatient(string id)
        {
            _ctx.ClosePatient();
            return _ctx.SetPatient(id);
        }


        public bool IsPatientAvailable(string piz)
        {
            return OpenPatient(piz);
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


        //public async IEnumerable<E.Course> GetCourses()
        public async void GetCourses()
        {

            //var cs = Task<IEnumerable<V.Course>>.Run(() =>
            //{
            //   return _ctx.Patient.Courses;
            //});

            //cs.Wait();
            //foreach (V.Course item in cs.Result)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var course in _ctx.Patient.Courses)
            //{
            //    _ctx.SetCourse(course);
            //    yield return _ctx.Course
            //}
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