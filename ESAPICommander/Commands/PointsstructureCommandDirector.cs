using ESAPICommander.ArgumentConfig;
using ESAPIProxy;
using ESAPICommander.Logger;


namespace ESAPICommander.Commands
{
    public class PointsstructureCommandDirector : BaseCommandDirector
    {
        private PointsstructureArgOptions _options;

        public PointsstructureCommandDirector(PointsstructureArgOptions options, ESAPIManager esapi, ILog log) :
            base(esapi, log, options.PIZ)
        {
            _options = options;
        }

        public override void Run()
        {

            
        }

        public override void ProcessRequest()
        {
            throw new System.NotImplementedException();
        }

        public override void PostProcess()
        {
            throw new System.NotImplementedException();
        }
    }
}