namespace ESAPIProxy
{
    public class Tag
    {
        // The actual object
        public int ParentID { get; set; }
        public int ID { get; set; }

        public string Description { get; set; }

        public Tag(string description)
        {
            Description = description;
        }

        public override string ToString()
        {
            return $"{nameof(ParentID)}: {ParentID}, {nameof(ID)}: {ID}, {nameof(Description)}: {Description}";
        }
    }
}