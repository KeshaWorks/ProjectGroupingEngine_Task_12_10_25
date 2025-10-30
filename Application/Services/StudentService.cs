using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces.ForRepositories;
using Application.Interfaces.ForServices;
using AutoMapper;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepositorie _studentRepositorie;
        private readonly IMapper _mapper;

        private readonly ILogger<StudentService> _logger;

        public StudentService(
            IStudentRepositorie studentRepositorie,
            IMapper mapper,
            ILogger<StudentService> logger)
        {
            _studentRepositorie = studentRepositorie;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AddStudentResponse> AddStudentAsync(AddStudentRequest addStudentRequest)
        {
            Student student = _mapper.Map<Student>(addStudentRequest);

            await _studentRepositorie.AddStudentAsync(student);

            AddStudentResponse addStudentResponse = _mapper.Map<AddStudentResponse>(student);

            return addStudentResponse;
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