namespace ESAPIProxy
{
    public class TagInfo
    {
        // The actual object
        public int ParentID { get; set; }
        public int ID { get; set; }

        public string Description { get; set; }

        public TagInfo(string description)
        {
            Description = description;
        }

        public override string ToString()
        {
            return $"{Description}";
        }
    }
}