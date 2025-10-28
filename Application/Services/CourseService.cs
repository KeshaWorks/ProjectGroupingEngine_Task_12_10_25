using Application.DTOs.Requests;
using Application.Interfaces.ForRepositories;
using Application.Interfaces.ForServices;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepositorie _courseRepositorie;
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;

        private readonly ILogger<CourseService> _logger;

        public CourseService(
            ICourseRepositorie courseRepositorie, 
            ILogger<CourseService> logger,
            IGroupService groupService,
            IStudentService studentService)
        {
            _courseRepositorie = courseRepositorie;
            _logger = logger;
            _groupService = groupService;
            _studentService = studentService;
        }

        public async Task<Course> AddCourseAsync(AddCourseRequest addCourseRequest)
        {
            Course course = new Course()
            {
                Title = addCourseRequest.Title,
                MaxGroupSize = addCourseRequest.MaxGroupSize,
                MinGroupSize = addCourseRequest.MinGroupSize,
                RequiredCompetencies = addCourseRequest.RequiredCompetencies,
            };

            await _courseRepositorie.AddCourseAsync(course);

            return course;
        }

        public async Task<StudentEnrollment> EnrollmentStudentAsync(EnrollmentStudentRequest enrollmentStudentRequest)
        {
            StudentEnrollment studentEnrollment = new StudentEnrollment()
            {
                CourseId = enrollmentStudentRequest.CourseId,
                StudentId = enrollmentStudentRequest.StudentId,
                BlacklistedPeerIds = enrollmentStudentRequest.BlacklistedPeerIds,
                PreferredPeerIds = enrollmentStudentRequest.PreferredPeerIds,
                Status = "Pending"
            };

            Student student = await _studentService.GetStudentAsync(studentEnrollment.StudentId);

            student.CourseId = studentEnrollment.CourseId;

            await _groupService.AddStudentInGroupAsync(student);

            await _courseRepositorie.EnrollmentStudentAsync(studentEnrollment);

            return studentEnrollment;
        }

        public async Task<List<string>> GetAllCompetenciesAsync()
        {
            List<Course> courses = await _courseRepositorie.GetAllCoursesAsync();

            List<string> competencies = new List<string>();

            for (int i = 0; i < courses.Count; i++)
            {
                competencies.Add(courses[i].RequiredCompetencies);
            }

            return competencies.Distinct().ToList();
        }
    }
}