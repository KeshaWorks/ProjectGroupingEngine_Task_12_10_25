using Application.DTOs.Responses;
using Domain;

namespace Application.Interfaces.ForServices
{
    public interface IGroupService
    {
        public Task AddStudentInGroupAsync(Student student);
        public Task<GetGroupsResponse> GetGroupsAsync(int courseId);
        //public Task<GetGroupsResponse> AddGroupsAsync(int courseId);
    }
}