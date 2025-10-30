namespace Application.DTOs.Secondary
{
    public record ParticularGroup
    {
        public int Id { get; init; }
        public List<int> MembersIds { get; init; } = new List<int>();
    }
}