using Application.DTOs;
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

        private static int _globalId = 0;

        public StudentService(IStudentRepositorie studentRepositorie, ILogger<StudentService> logger)
        {
            _studentRepositorie = studentRepositorie;
            _logger = logger;
        }

        public async Task<AddStudentResponse> AddStudentAsync(AddStudentRequest addStudentRequest)
        {
            Student student = new Student()
            {
                Id = ++_globalId,
                FullName = addStudentRequest.FullName,
                Email = addStudentRequest.Email,
                Competencies = addStudentRequest.Competencies
            };

            await _studentRepositorie.AddStudentAsync(addStudentRequest);

            AddStudentResponse addStudentResponse = new AddStudentResponse()
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                Competencies = student.Competencies
            };

            return addStudentResponse;
        }
    } 
}