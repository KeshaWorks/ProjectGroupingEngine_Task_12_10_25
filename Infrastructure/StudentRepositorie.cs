using Domain;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class StudentRepositorie
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
            _appDbContext.Students.Add(student);

            await _appDbContext.SaveChangesAsync();
        }
    }
}