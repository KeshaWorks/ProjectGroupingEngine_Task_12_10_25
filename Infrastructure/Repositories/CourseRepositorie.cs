using Application.Interfaces.ForRepositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class CourseRepositorie : ICourseRepositorie
    {
        private readonly AppDbContext _appDbContext;

        private readonly ILogger<CourseRepositorie> _logger;

        public CourseRepositorie(AppDbContext appDbContext, ILogger<CourseRepositorie> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task AddCourseAsync(Course course)
        {
            await _appDbContext.Courses.AddAsync(course);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task EnrollmentStudentAsync(StudentEnrollment studentEnrollment)
        {
            await _appDbContext.StudentEnrollments.AddAsync(studentEnrollment);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            List<Course> courses = await _appDbContext.Courses.ToListAsync();

            return courses;
        }
    }
}