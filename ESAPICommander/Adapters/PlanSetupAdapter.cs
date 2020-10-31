using ESAPICommander.Interfaces;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace ESAPICommander.Adapters
{
    public class PlanSetupAdapter :IPlanSetup
    {
        private PlanSetup _planSetup { get; }

        public PlanSetupAdapter(PlanSetup planSetup)
        {
            _planSetup = planSetup;
        }

        public string Id => _planSetup.Id;

        public ICourse Course => new CourseAdapter(_planSetup.Course);

        public DoseValue TotalDose => _planSetup.TotalDose;
        public IStructureSet StructureSet { get; }

        public int? NumberOfFractions => _planSetup.NumberOfFractions;
    }
}