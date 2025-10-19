namespace Application.DTOs
{
    public record AddStudentResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Competencies { get; set; }
    }
}