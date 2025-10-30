using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Domain;

namespace Application.Interfaces.ForServices
{
    public interface IStudentService
    {
        public Task<AddStudentResponse> AddStudentAsync(AddStudentRequest addStudentRequest);
        public Task<List<string>> GetAllCompetenciesAsync();
    }
}