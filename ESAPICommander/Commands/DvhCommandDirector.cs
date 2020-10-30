using ESAPICommander.Logger;
using ESAPICommander.Proxies;

namespace ESAPICommander.Commands
{
    public class DvhCommandDirector : BaseCommandDirector
    {
        public override void Run()
        {
            throw new System.NotImplementedException();
        }

        public DvhCommandDirector(IEsapiCalls esapi, ILog log) : base(esapi, log)
        {
        }
    }
}