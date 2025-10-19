namespace Application.DTOs
{
    public record AddStudentRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Competencies {  get; set; }
    }
}