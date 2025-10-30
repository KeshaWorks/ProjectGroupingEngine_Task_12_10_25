using Application.Interfaces.ForRepositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class StudentRepositorie : IStudentRepositorie
    {
        private readonly AppDbContext _appDbContext;

        private readonly ILogger<StudentRepositorie> _logger;

        public StudentRepositorie(AppDbContext appDbContext, ILogger<StudentRepositorie> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task AddStudentAsync(Student student)
        {
            await _appDbContext.Students.AddAsync(student);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Student> GetStudentAsync(int studentId)
        {
            List<Student> students = await _appDbContext.Students.ToListAsync();

            Student student = students.Find(x => x.Id == studentId);

            return student;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = await _appDbContext.Students.ToListAsync();

            return students;
        }

        public async Task<StudentEnrollment> GetStudentEnrollmentAsync(int studentId)
        {
            List<StudentEnrollment> studentEnrollments = await _appDbContext.StudentEnrollments.ToListAsync();

            StudentEnrollment studentEnrollment = studentEnrollments.Find(x => x.StudentId == studentId);

            return studentEnrollment;
        }

        public async Task<List<Student>> GetStudentsByCourseIdAsync(int courseId)
        {
            List<Student> students = await _appDbContext.Students.ToListAsync();

            List<Student> studentsByCourseId = students.FindAll(x => x.CourseId == courseId).ToList();

            return studentsByCourseId;
        }
    }
}