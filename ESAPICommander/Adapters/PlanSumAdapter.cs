using System.Collections.Generic;
using System.Linq;
using ESAPICommander.Interfaces;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Adapters
{
    public class PlanSumAdapter : IPlanSum
    {
        private PlanSum _planSum { get; }

        public PlanSumAdapter(PlanSum planSum)
        {
            _planSum = planSum;
        }

        public string Id => _planSum.Id;

        public IEnumerable<IPlanSetup> PlanSetups => _planSum.PlanSetups.Select(x=>new PlanSetupAdapter(x));
        public ICourse Course => new CourseAdapter(_planSum.Course);
    }
}