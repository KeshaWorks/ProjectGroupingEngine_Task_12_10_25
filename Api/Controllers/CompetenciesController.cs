using Application.Interfaces.ForServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class CompetenciesController : ControllerBase
    {
        private readonly IСompetenciesManagerService _сompetenciesManagerService;

        private readonly ILogger<CompetenciesController> _logger;

        public CompetenciesController(
            IСompetenciesManagerService сompetenciesManagerService, 
            ILogger<CompetenciesController> logger)
        {
            _сompetenciesManagerService = сompetenciesManagerService;
            _logger = logger;
        }

        [HttpGet("competencies")]
        public async Task<IActionResult> GetAllCompetenciesAsync()
        {
            List<string> competencies = await _сompetenciesManagerService.GetAllCompetenciesAsync();

            return Ok(competencies);
        }
    }
}