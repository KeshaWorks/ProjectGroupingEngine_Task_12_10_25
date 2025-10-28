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
            Student student = await _appDbContext.Students.FindAsync(studentId);

            return student;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = await _appDbContext.Students.ToListAsync();

            return students;
        }
    }
}