namespace Application.DTOs.Requests
{
    public record EnrollmentStudentRequest
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public List<int> PreferredPeerIds { get; set; } = new List<int>();
        public List<int> BlacklistedPeerIds { get; set; } = new List<int>();
    }
}