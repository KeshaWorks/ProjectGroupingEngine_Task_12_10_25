using Application.DTOs;

namespace Application.Interfaces.ForServices
{
    public interface IStudentService
    {
        public Task<AddStudentResponse> AddStudentAsync(AddStudentRequest addStudentRequest);
    }
}