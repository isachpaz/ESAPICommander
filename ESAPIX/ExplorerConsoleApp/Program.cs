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

            Debug.WriteLine($"User = {em.GetUser().Id}");
            Debug.WriteLine($"Total # of patients = {em.GetPatientSummaries().ToList().Count}");

            var isPatientOpened = em.OpenPatientbyId("123456789");
            var courses = em.GetCourse();


            em.Dispose();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debug.WriteLine((e.ExceptionObject as Exception).Message);
        }
    }
}