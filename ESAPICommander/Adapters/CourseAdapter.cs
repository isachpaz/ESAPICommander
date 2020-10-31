using System.Collections.Generic;
using System.Linq;
using ESAPICommander.Interfaces;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Adapters
{
    public class CourseAdapter : ICourse
    {
        private Course _course { get; }

        public CourseAdapter(Course course)
        {
            _course = course;
        }

        
        public string Id => _course.Id;

        public IEnumerable<IPlanSetup> PlanSetups => _course.PlanSetups.Select(x=>new PlanSetupAdapter(x));

        public IEnumerable<IPlanSum> PlanSums => _course.PlanSums.Select(x=>new PlanSumAdapter(x));
    }
}