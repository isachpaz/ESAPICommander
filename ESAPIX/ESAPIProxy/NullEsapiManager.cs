using ESAPIX.Common;

namespace ESAPIProxy
{
    public class NullEsapiManager : ESAPIManager
    {
        public NullEsapiManager() : base(null)
        {
        }
    }
}