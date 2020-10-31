using System.Collections.Generic;

namespace ESAPICommander.Interfaces
{
    public interface IPlanSum
    {
        string Id { get; }
        IEnumerable<IPlanSetup> Plans { get; }
        ICourse Course { get; }
    }
}