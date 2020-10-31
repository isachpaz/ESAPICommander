using System.Collections.Generic;

namespace ESAPICommander.Interfaces
{
    public interface ICourse
    {
        string Id { get; }
        IEnumerable<IPlanSetup> PlanSetups { get; }
        IEnumerable<IPlanSum> PlanSums { get; }


    }
}