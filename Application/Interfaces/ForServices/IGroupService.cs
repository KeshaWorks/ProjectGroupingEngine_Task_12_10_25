using Application.DTOs.Responses;
using Domain;

namespace Application.Interfaces.ForServices
{
    public interface IGroupService
    {
        public Task<GetGroupsResponse> GetGroupsAsync(int courseId);
        public Task AddStudentInGroupAsync(Student student);
    }
}