namespace Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MinGroupSize { get; set; }
        public int MaxGroupSize { get; set; }
        public string RequiredCompetencies {  get; set; }
    }
}