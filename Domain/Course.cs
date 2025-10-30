namespace Domain
{
    public class Course
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public int MinGroupSize { get; init; }
        public int MaxGroupSize { get; init; }
        public string RequiredCompetencies {  get; init; }
    }
}