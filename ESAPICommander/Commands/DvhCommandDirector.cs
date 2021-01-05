using System;
using System.Collections.Generic;
using System.Linq;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Logger;
using ESAPIProxy;

namespace ESAPICommander.Commands
{
    public class DvhCommandDirector : BaseCommandDirector
    {
        private readonly DvhArgOptions _options;
        private List<string> _results = new List<string>();

        public override void ProcessRequest()
        {
            try
            {
                var patient = _esapi.GetPatient();
                _results = _esapi.ExtractDVHs(_options.Course, _options.Plan, _options.Structures.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

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