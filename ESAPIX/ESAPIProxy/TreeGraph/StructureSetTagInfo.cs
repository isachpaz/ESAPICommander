namespace ESAPIProxy.TreeGraph
{
    public class StructureSetTagInfo : TagInfo
    {
        public StructureSetTagInfo(string description) : base(description)
        {
        }

        public override string ToString()
        {
            return $"StructureSet: {base.ToString()}";
        }
    }
}