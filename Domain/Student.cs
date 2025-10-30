namespace Domain
{
    public class Student
    {
        public int Id { get; init; }
        public int GroupId { get; init; }
        public int CourseId { get; init; }
        public string FullName { get; init; }
        public string Email { get; init; }
        public string Competencies { get; init; }
    }
}