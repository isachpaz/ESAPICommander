namespace ESAPIProxy.PatientTree
{
    public class PlanSetupTagInfo : TagInfo
    {
        public PlanSetupTagInfo(string description) : base(description)
        {
        }

        public override string ToString()
        {
            return $"PlanSetup: {base.ToString()}";
        }
    }
}