using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC = ESAPIX.Common;
using E = ESAPIX.Facade.API;
using V = VMS.TPS.Common.Model.API;

namespace ESAPIProxy
{
    public class ESAPIManager : IDisposable
    {
        private readonly EC.AppComThread _thread;

        protected ESAPIManager(ESAPIX.Common.AppComThread _thread)
        {
            this._thread = _thread;
        }

        public static ESAPIManager CreateEsapiThreadDefault(Func<V.Application> createAppFunc)
        {
            try
            {
                ESAPIX.Common.AppComThread.Instance.SetContext(createAppFunc);
                return new ESAPIManager(ESAPIX.Common.AppComThread.Instance);
            }
            //catch (Exception e)
            //{

            //}
            catch (System.ApplicationException sae)
            {

            }

            return new NullEsapiManager();
        }

        public E.User GetUser()
        {
            return _thread.GetValue(ctx =>
            {
                var user = new ESAPIX.Facade.API.User {Name = ctx.CurrentUser.Name, Id = ctx.CurrentUser.Id};
                return user;
            });
        }

        public bool OpenPatientbyId(string zip)
        {
            return _thread.GetValue(ctx =>
            {
                var result = ctx.SetPatient(zip);
                return result;
            });
        }

        public E.Patient GetPatient()
        {
            return _thread.GetValue(ctx =>
            {
                var patient = new E.Patient() { Name = ctx.CurrentUser.Name, Id = ctx.CurrentUser.Id };
                return patient;
            });
        }

        public IEnumerable<E.PatientSummary> GetPatientSummaries()
        {
            return _thread.GetValue(ctx =>
            {
                var summaries = ctx.Application.PatientSummaries;
                List<E.PatientSummary> list = new List<E.PatientSummary>();
                foreach (V.PatientSummary item in summaries)
                {
                    var ps = new E.PatientSummary
                    {
                        FirstName = item.FirstName, LastName = item.LastName, Id = item.Id
                    };
                    list.Add(ps);
                }
                return list;
            });
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                _thread?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ESAPIManager()
        {
            Dispose(false);
        }

        public IEnumerable<E.Course> GetCourse()
        {
            return _thread.GetValue(ctx =>
            {
                var ss = ctx.Course.PlanSetups;
                var courses = ctx.Patient?.Courses;
                var list = new List<E.Course>();
                foreach ( var item in courses)
                {
                    var ps = new E.Course()
                    {
                        Id = item.Id,
                        Patient = new E.Patient()
                        {
                            Id = item.Patient.Id, FirstName = item.Patient.FirstName, LastName = item.Patient.LastName
                        },
                    };

                    var planSetups = new List<E.PlanSetup>();
                    foreach (V.PlanSetup planSetup in item.PlanSetups)
                    {
                        var newPlanSetup = new E.PlanSetup();
                        planSetups.Add(newPlanSetup);
                    }

                    list.Add(ps);
                }
                return list;
            });
        }
    }
}