using AutoMapper;
using MTS.Application.DTOs.Advisors;
using MTS.Application.DTOs.Students;
using MTS.Application.DTOs.Theses;
using MTS.Domain.Entities;

namespace MTS.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Student Mapping
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();

            // Advisor Mapping
            CreateMap<Advisor, AdvisorDto>().ReverseMap();
            CreateMap<Advisor, CreateAdvisorDto>().ReverseMap();
            CreateMap<Advisor, UpdateAdvisorDto>().ReverseMap();

            // Thesis Mapping
            CreateMap<ThesisTopic, ThesisDto>().ReverseMap();
            CreateMap<ThesisTopic, CreateThesisDto>().ReverseMap();
            CreateMap<ThesisTopic, UpdateThesisDto>().ReverseMap();
        }
    }
}
