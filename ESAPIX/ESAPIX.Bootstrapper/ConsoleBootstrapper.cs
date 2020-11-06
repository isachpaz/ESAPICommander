using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ESAPIX.AppKit.Overlay;
using ESAPIX.Common;
using ESAPIX.Common.Args;
using ESAPIX.Interfaces;
using Prism.Events;

namespace ESAPIX.Bootstrapper
{
    public class ConsoleBootstrapper
    {
//        protected IScriptContext _ctx;
        private EventAggregator _ea;

        public ConsoleBootstrapper(Func<VMS.TPS.Common.Model.API.Application> createAppFunc)
        {
            var thread = AppComThread.Instance;
            thread.SetContext(createAppFunc);

            //var sac = _ctx as StandAloneContext;
            //var selectPat = new SelectPatient();
            
        }

        private List<Facade.API.PatientSummary> _summaries;

        public void LoadSummaries()
        {
            //patientId.IsEnabled = false;
            AppComThread.Instance.Invoke( () =>
            {
                //UpdateStatus("Caching Summaries...");
                _summaries = AppComThread.Instance.GetValue(sac =>
                {
                    return sac.Application.PatientSummaries.Select(p => new Facade.API.PatientSummary()
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                    }).ToList();
                });
                //UpdateStatus("");
            });
            
            Console.WriteLine(_summaries);
            //patientId.IsEnabled = true;
        }
        public void Run(string[] commandLineArgs)
        {
            AppComThread.Instance.Execute((sc) =>
            {
                ArgContextSetter.Set(sc, commandLineArgs);
            });
        }

        private void OnContentRendered(object sender)
        {
            
        }
    }
}