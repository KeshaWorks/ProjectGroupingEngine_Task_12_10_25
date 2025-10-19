using Application.DTOs;

namespace Application.Interfaces.ForRepositories
{
    public interface IStudentRepositorie
    {
        Task AddStudentAsync(AddStudentRequest addStudentRequest);
    }
}