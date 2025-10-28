using Application.DTOs.Secondary;

namespace Application.DTOs.Responses
{
    public record GetGroupsResponse
    {
        public int Id { get; set; }
        public List<ParticularGroup> Groups { get; set; } = new List<ParticularGroup>();
    }
}