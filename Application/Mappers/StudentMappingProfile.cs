using Application.DTOs.Requests;
using Application.DTOs.Responses;
using AutoMapper;
using Domain;

namespace Application.Mappers
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile() 
        {
            CreateMap<AddStudentRequest, Student>();
            CreateMap<Student, AddStudentResponse>();
        }
    }
}