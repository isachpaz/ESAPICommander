using ESAPICommander.ArgumentConfig;
using ESAPIProxy;
using ESAPICommander.Logger;


namespace ESAPICommander.Commands
{
    public class PointsstructureCommandDirector : BaseCommandDirector
    {
        private PointsstructureArgOptions _options;

        public PointsstructureCommandDirector(PointsstructureArgOptions options, ESAPIManager esapi, ILog log) :
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