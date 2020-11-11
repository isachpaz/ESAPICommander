namespace ESAPIProxy
{
    public class PatientTagInfo : TagInfo
    {
        public PatientTagInfo(string description) : base(description)
        {
        }

        public override string ToString()
        {
            return $"Patient: {base.Description}";
        }
    }
}