namespace Application.DTOs.Responses
{
    public record AddStudentResponse
    {
        public int Id { get; init; }
        public string FullName { get; init; }
        public string Email { get; init; }
        public string Competencies { get; init; }
    }
}