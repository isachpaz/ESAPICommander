using ESAPICommander.ArgumentConfig;
using ESAPICommander.Logger;
using ESAPIProxy;

namespace ESAPICommander.Commands
{
    public class DvhCommandDirector : BaseCommandDirector
    {
        private readonly DvhArgOptions _options;

        public override int Run()
        {
            throw new System.NotImplementedException();
        }

        public DvhCommandDirector(DvhArgOptions options, ESAPIManager esapi, ILog log) : base(esapi, log)
        {
            _options = options;
        }
    }
}