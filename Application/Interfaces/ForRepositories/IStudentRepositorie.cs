using Domain;

namespace Application.Interfaces.ForRepositories
{
    public interface IStudentRepositorie
    {
        public Task AddStudentAsync(Student student);
        public Task<Student> GetStudentAsync(int studentId);
        public Task<List<Student>> GetAllStudentsAsync();
        public Task<StudentEnrollment> GetStudentEnrollmentAsync(int studentId);
        public Task<List<Student>> GetStudentsByCourseIdAsync(int courseId);
    }
}