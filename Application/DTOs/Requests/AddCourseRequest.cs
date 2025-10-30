namespace Application.DTOs.Requests
{
    public record AddCourseRequest
    {
        public string Title { get; init; }
        public int MinGroupSize { get; init; }
        public int MaxGroupSize { get; init; }
        public string RequiredCompetencies { get; init; }
    }
}