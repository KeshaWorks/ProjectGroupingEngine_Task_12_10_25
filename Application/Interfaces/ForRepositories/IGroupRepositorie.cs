using Application.DTOs.Secondary;
using Domain;

namespace Application.Interfaces.ForRepositories
{
    public interface IGroupRepositorie
    {
        public Task AddStudentInGroupAsync(Student student);
        public Task<List<ParticularGroup>> GetGroupsByCourseIdAsync(int courseId);
        //public Task<GetGroupsResponse> AddGroupsAsync(int courseId);
    }
}