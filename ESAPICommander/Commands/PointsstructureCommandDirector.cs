using ESAPICommander.ArgumentConfig;
using ESAPICommander.Esapi;
using ESAPICommander.Logger;
using ESAPIX.Interfaces;

namespace ESAPICommander.Commands
{
    public class PointsstructureCommandDirector : BaseCommandDirector
    {
        private PointsstructureArgOptions _options;

        public PointsstructureCommandDirector(PointsstructureArgOptions options, EsapiManager esapi, ILog log) :
            base(esapi, log)
        {
            _options = options;
        }

        public override int Run()
        {

            return 0;
        }

    }
}