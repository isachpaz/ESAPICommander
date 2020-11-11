using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Threading;
using ESAPIProxy;

namespace ExplorerConsoleApp
{
    class Program
    {
        //[STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            var em = ESAPIManager.CreateEsapiThreadDefault(() =>
                VMS.TPS.Common.Model.API.Application.CreateApplication());

            var patientSummaries = em.GetPatientSummaries().ToList();

            Debug.WriteLine($"User = {em.GetUser().Id}");
            Debug.WriteLine($"Total # of patients = {patientSummaries.Count}");

            var isPatientOpened = em.OpenPatientbyId(patientSummaries.FirstOrDefault(x=>x.Id.Contains("Prostata_")).Id);
            var courses = em.GetCourses();


            em.Dispose();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debug.WriteLine((e.ExceptionObject as Exception).Message);
        }
    }
}