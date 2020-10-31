using ESAPICommander.Logger;
using ESAPICommander.Proxies;

namespace ESAPICommander.Commands
{
    public class PointsstructureCommandDirector : BaseCommandDirector
    {
        public override int Run()
        {
            throw new System.NotImplementedException();
        }

        public PointsstructureCommandDirector(IEsapiCalls esapi, ILog log) : base(esapi, log)
        {
        }
    }
}