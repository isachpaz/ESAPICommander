using ESAPICommander.Esapi;
using ESAPICommander.Logger;
using ESAPIX.Interfaces;

namespace ESAPICommander.Commands
{
    public class DvhCommandDirector : BaseCommandDirector
    {
        public override int Run()
        {
            throw new System.NotImplementedException();
        }

        public DvhCommandDirector(EsapiManager esapi, ILog log) : base(esapi, log)
        {
        }
    }
}