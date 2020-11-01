using ESAPICommander.ArgumentConfig;
using ESAPICommander.Logger;
using ESAPICommander.Proxies;

namespace ESAPICommander.Commands
{
    public class PointsstructureCommandDirector : BaseCommandDirector
    {
        private PointsstructureArgOptions _options;

        public PointsstructureCommandDirector(PointsstructureArgOptions options, IEsapiCalls esapi, ILog log) :
            base(esapi, log)
        {
            _options = options;
        }

        public override int Run()
        {
            throw new System.NotImplementedException();
        }

    }
}