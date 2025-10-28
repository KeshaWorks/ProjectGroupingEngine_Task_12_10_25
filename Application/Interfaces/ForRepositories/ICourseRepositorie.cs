using Domain;

namespace Application.Interfaces.ForRepositories
{
    public interface ICourseRepositorie
    {
        public Task AddCourseAsync(Course course);
        public Task EnrollmentStudentAsync(StudentEnrollment studentEnrollment);
        public Task<List<Course>> GetAllCoursesAsync();
    }
}