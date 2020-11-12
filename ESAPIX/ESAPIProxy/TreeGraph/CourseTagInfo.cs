namespace ESAPIProxy
{
    public class CourseTagInfo : TagInfo
    {
        public CourseTagInfo(string description) : base(description)
        {
        }

        public override string ToString()
        {
            return $"Course: {base.Description}";
        }
    }
}