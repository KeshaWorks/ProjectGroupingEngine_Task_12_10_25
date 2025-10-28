using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces.ForRepositories;
using Application.Interfaces.ForServices;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepositorie _studentRepositorie;

        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepositorie studentRepositorie, ILogger<StudentService> logger)
        {
            _studentRepositorie = studentRepositorie;
            _logger = logger;
        }

        public async Task<AddStudentResponse> AddStudentAsync(AddStudentRequest addStudentRequest)
        {
            Student student = new Student()
            {
                FullName = addStudentRequest.FullName,
                Competencies = addStudentRequest.Competencies,
                Email = addStudentRequest.Email
            };

            await _studentRepositorie.AddStudentAsync(student);

            AddStudentResponse addStudentResponse = new AddStudentResponse()
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                Competencies = student.Competencies
            };

            return addStudentResponse;
        }

        public async Task<Student> GetStudentAsync(int studentId)
        {
            return await _studentRepositorie.GetStudentAsync(studentId);
        }

        public async Task<List<string>> GetAllCompetenciesAsync()
        {
            List<Student> students = await _studentRepositorie.GetAllStudentsAsync();

            List<string> competencies = new List<string>();

            for (int i = 0; i < students.Count; i++)
            {
                competencies.Add(students[i].Competencies);
            }

            return competencies.Distinct().ToList();
        }
    } 
}