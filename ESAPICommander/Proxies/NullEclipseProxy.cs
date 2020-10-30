using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Proxies
{
    public class NullEclipseProxy : IEsapiCalls
    {
        public void Dispose()
        {
            
        }

        public bool IsPatientAvailable(string piz)
        {
            return false;
        }

        public Patient OpenPatient(string piz)
        {
            return null;
        }

        public void ClosePatient(string piz)
        {
            
        }
    }
}