namespace SQLProject
{
    internal class PersonModel
    {
        public int id { get; set; }
        public string? person_name { get; set; }
        public int person_id { get; set; }
        public List<ProjectPersonModel> ProjectPersons { get; set; }
    }
}