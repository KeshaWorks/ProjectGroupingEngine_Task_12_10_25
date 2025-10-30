namespace Application.DTOs.Requests
{
    public record EnrollmentStudentRequest
    {
        public int StudentId { get; init; }
        public int CourseId { get; init; }
        public List<int> PreferredPeerIds { get; init; } = new List<int>();
        public List<int> BlacklistedPeerIds { get; init; } = new List<int>();
    }
}