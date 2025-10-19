using Application.DTOs;
using Application.Interfaces.ForServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentService studentService, ILogger<StudentsController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpPost("students")]
        public async Task<IActionResult> AddStudent([FromBody]AddStudentRequest addStudentRequest)
        {
            AddStudentResponse addStudentResponse = await _studentService.AddStudentAsync(addStudentRequest);

            return Ok(addStudentResponse);
        }
    }
}