using System;
using System.Linq;
using ESAPICommander.ArgumentConfig;
using ESAPICommander.Interfaces;
using ESAPICommander.Logger;
using ESAPIProxy;


namespace ESAPICommander.Commands
{
    public class DumpCommandDirector : BaseCommandDirector
    {
        private DumpArgOptions _options;

        public DumpCommandDirector(DumpArgOptions options, ESAPIManager esapi, ILog log) : base(esapi, log)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override int Run()
        {
            if (!IsPIZAvailable(_options.PIZ))
            {
                _log.AddInfo($"Patient with PIZ={_options.PIZ} cannot be found...");
                _log.AddInfo("Process stopped.");
                return -1;
            }
            else
            {
                _log.AddInfo($"Patient with PIZ={_options.PIZ} found.");
            }

            

            return 0;
        }

    }
}