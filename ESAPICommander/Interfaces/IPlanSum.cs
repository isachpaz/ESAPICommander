using System.Collections.Generic;

namespace ESAPICommander.Interfaces
{
    public interface IPlanSum
    {
        string Id { get; }
        IEnumerable<IPlanSetup> PlanSetups { get; }
        ICourse Course { get; }
    }
}