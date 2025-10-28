using Application.DTOs.Requests;
using Application.Interfaces.ForServices;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ICourseService courseService, ILogger<CoursesController> logger)
        {
            _courseService = courseService;
            _logger = logger;
        }

        [HttpPost("courses")]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseRequest addCourseRequest)
        {
            Course course = await _courseService.AddCourseAsync(addCourseRequest);

            return Ok(course);
        }

        [HttpPost("enrollments")]
        public async Task<IActionResult> EnrollmentStudent(EnrollmentStudentRequest enrollmentStudentRequest)
        {
            StudentEnrollment studentEnrollment = 
                await _courseService.EnrollmentStudentAsync(enrollmentStudentRequest);

            return Ok(studentEnrollment);
        }
    }
}