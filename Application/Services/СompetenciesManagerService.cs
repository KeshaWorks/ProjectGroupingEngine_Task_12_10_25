using Application.Interfaces.ForServices;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class СompetenciesManagerService : IСompetenciesManagerService
    {
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        private readonly ILogger<СompetenciesManagerService> _logger;

        public СompetenciesManagerService(
            ICourseService courseService, 
            IStudentService studentService, 
            ILogger<СompetenciesManagerService> logger)
        {
            _courseService = courseService;
            _studentService = studentService;
            _logger = logger;
        }

        public async Task<List<string>> GetAllCompetencies()
        {
            List<string> coursesCompetencies = await _courseService.GetAllCompetenciesAsync();

            List<string> studentsCompetencies = await _studentService.GetAllCompetenciesAsync();

            return coursesCompetencies.Union(studentsCompetencies).ToList();
        }
    }
}