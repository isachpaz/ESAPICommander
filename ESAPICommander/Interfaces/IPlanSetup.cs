


using VMS.TPS.Common.Model.Types;

namespace ESAPICommander.Interfaces
{
    public interface IPlanSetup
    {
        string Id { get; }
        ICourse Course { get; }
        DoseValue TotalDose { get; }
        IStructureSet StructureSet { get; }
        int? NumberOfFractions { get; }
    }
}