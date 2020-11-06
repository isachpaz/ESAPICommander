using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using ESAPIProxy;

namespace ExplorerConsoleApp
{
    class Program
    {
        //[STAThread]
        static void Main(string[] args)
        {
            var em = ESAPIManager.CreateEsapiThreadDefault(()=>VMS.TPS.Common.Model.API.Application.CreateApplication());

            Debug.WriteLine($"User = {em.Getuser().Id}");
            Debug.WriteLine($"Total # of patients = {em.GetPatientSummaries().ToList().Count}");

            em.Dispose();
        }
    }
}