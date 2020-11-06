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

        private ESAPIManager(ESAPIX.Common.AppComThread _thread)
        {
            this._thread = _thread;
        }

        public static ESAPIManager CreateEsapiThreadDefault(Func<V.Application> createAppFunc)
        {
            ESAPIX.Common.AppComThread.Instance.SetContext(createAppFunc);
            return new ESAPIManager(ESAPIX.Common.AppComThread.Instance);
        }

        public E.User GetUser()
        {
            return _thread.GetValue(ctx =>
            {
                var user = new ESAPIX.Facade.API.User {Name = ctx.CurrentUser.Name, Id = ctx.CurrentUser.Id};
                return user;
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
                    var ps = new ESAPIX.Facade.API.PatientSummary
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
    }
}