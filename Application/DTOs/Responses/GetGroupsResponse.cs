using Application.DTOs.Secondary;

namespace Application.DTOs.Responses
{
    public record GetGroupsResponse
    {
        public int Id { get; init; }
        public List<ParticularGroup> Groups { get; init; } = new List<ParticularGroup>();
    }
}