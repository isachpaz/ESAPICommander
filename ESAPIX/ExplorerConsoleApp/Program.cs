using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Threading;
using ESAPIProxy;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace ExplorerConsoleApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            //var em = ESAPIManager.CreateEsapiThreadDefault(() =>
            //    VMS.TPS.Common.Model.API.Application.CreateApplication());


            var app = VMS.TPS.Common.Model.API.Application.CreateApplication();
            var patient = app.OpenPatientById("Patient04_17710303");
            foreach (Study study in patient.Studies)
            {
                Console.WriteLine(study.Id + " " + study.Comment);
                foreach (Series series in study.Series)
                {
                    Console.WriteLine("\t"+series.Id + " " + series.Modality + " " + series.Comment);
                }
            }

            var petStudy = patient.Studies.FirstOrDefault(s => s.Id.Contains("6975"));
            var petSeries = petStudy.Series.FirstOrDefault(s => s.Modality == SeriesModality.PT);

            foreach (Image image in petSeries.Images)
            {
                int voxelPos = (image.XSize / 2) * (image.YSize/2) ;
                var suv = image.VoxelToDisplayValue(voxelPos);
                Console.WriteLine(suv);
            }




            app.Dispose();
            //var patientSummaries = em.GetPatientSummaries().ToList();

            //Debug.WriteLine($"User = {em.GetUser().Id}");
            //Debug.WriteLine($"Total # of patients = {patientSummaries.Count}");

            //var isPatientOpened = em.OpenPatientbyId(patientSummaries.FirstOrDefault(x=>x.Id.Contains("Prostata_")).Id);
            //var courses = em.GetCourses();


            //em.Dispose();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debug.WriteLine((e.ExceptionObject as Exception).Message);
        }
    }
}