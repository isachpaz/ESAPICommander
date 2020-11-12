using ESAPICommander.ArgumentConfig;
using ESAPICommander.Logger;
using ESAPIProxy;

namespace ESAPICommander.Commands
{
    public class DvhCommandDirector : BaseCommandDirector
    {
        private readonly DvhArgOptions _options;

        public override void Run()
        {
            throw new System.NotImplementedException();
        }

        public override void ProcessRequest()
        {
            throw new System.NotImplementedException();
        }

        public override void PostProcess()
        {
            throw new System.NotImplementedException();
        }

        public DvhCommandDirector(DvhArgOptions options, ESAPIManager esapi, ILog log) : base(esapi, log, options.PIZ)
        {
            _options = options;
        }
    }
}