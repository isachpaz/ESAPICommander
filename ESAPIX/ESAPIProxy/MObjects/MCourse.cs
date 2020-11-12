namespace ESAPIProxy.MObjects
{
    public class MCourse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public MPatient Patient { get; set; }
    }
}