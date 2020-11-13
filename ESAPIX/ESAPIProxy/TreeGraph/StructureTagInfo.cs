namespace ESAPIProxy.TreeGraph
{
    public class StructureTagInfo : TagInfo
    {
        public StructureTagInfo(string description) : base(description)
        {
        }

        public override string ToString()
        {
            return $"Structure: {base.ToString()}";
        }
    }
}