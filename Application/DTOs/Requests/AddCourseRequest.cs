namespace Application.DTOs.Requests
{
    public record AddCourseRequest
    {
        public string Title { get; set; }
        public int MinGroupSize { get; set; }
        public int MaxGroupSize { get; set; }
        public string RequiredCompetencies { get; set; }
    }
}