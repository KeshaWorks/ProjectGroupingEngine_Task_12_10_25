using Domain;

namespace Application.Interfaces.ForRepositories
{
    public interface IGroupRepositorie
    {
        public Task<int> AddGroupAsync(Group group);
        public Task<List<Group>> GetGroupsByCourseIdAsync(int courseId);
        public Task<List<Group>> GetAllGroupsAsync();
    }
}