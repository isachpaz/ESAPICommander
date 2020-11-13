using VMS.TPS.Common.Model.Types;

namespace ESAPIProxy
{
    public class VoxelData
    {
        public string PatientId { get; set; }
        public string CourseId { get; set; }
        public string PlanId { get; set; }
        public string StructureId { get; set; }
        public VVector Position { get; set; }
        public int I { get; set; }
        public int J { get; set; }
        public int K { get; set; }
        public DoseValue DoseToPoint { get; set; }
        public double OriginX { get; set; }
        public double OriginY { get; set; }
        public double OriginZ { get; set; }
        public double XRes { get; set; }
        public double YRes { get; set; }
        public double ZRes { get; set; }
        public VVector XDirection { get; set; }
        public VVector YDirection { get; set; }
        public VVector ZDirection { get; set; }

        public override string ToString()
        {
            return $"{nameof(PatientId)}: {PatientId}, {nameof(CourseId)}: {CourseId}, {nameof(PlanId)}: {PlanId}, {nameof(StructureId)}: {StructureId}, {nameof(I)}: {I}, {nameof(J)}: {J}, {nameof(K)}: {K}, {nameof(DoseToPoint)}: {DoseToPoint}, {nameof(OriginX)}: {OriginX}, {nameof(OriginY)}: {OriginY}, {nameof(OriginZ)}: {OriginZ}, {nameof(XRes)}: {XRes}, {nameof(YRes)}: {YRes}, {nameof(ZRes)}: {ZRes}";
        }
    }
}