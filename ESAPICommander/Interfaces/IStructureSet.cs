using System.Collections.Generic;

namespace ESAPICommander.Interfaces
{
    public interface IStructureSet
    {
        string Id { get; }
        IEnumerable<IStructure> Structures { get; }
    }
}