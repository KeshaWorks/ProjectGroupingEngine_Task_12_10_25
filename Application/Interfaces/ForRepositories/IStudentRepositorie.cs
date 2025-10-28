using Domain;

namespace Application.Interfaces.ForRepositories
{
    public interface IStudentRepositorie
    {
        Task AddStudentAsync(Student student);
        public Task<Student> GetStudentAsync(int studentId);
        public Task<List<Student>> GetAllStudentsAsync();
    }
}