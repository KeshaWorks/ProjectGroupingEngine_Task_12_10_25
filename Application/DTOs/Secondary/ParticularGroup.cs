namespace Application.DTOs.Secondary
{
    public record ParticularGroup
    {
        public int Id { get; set; }
        public List<int> MembersIds { get; set; } = new List<int>();
    }
}