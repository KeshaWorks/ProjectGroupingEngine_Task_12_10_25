using Application.DTOs.Requests;
using Domain;

namespace Application.Interfaces.ForServices
{
    public interface ICourseService
    {
        public Task<Course> AddCourseAsync(AddCourseRequest addCourseRequest);
        public Task<StudentEnrollment> EnrollmentStudentAsync(EnrollmentStudentRequest enrollmentStudentRequest);
        public Task<List<string>> GetAllCompetenciesAsync();
    }
}