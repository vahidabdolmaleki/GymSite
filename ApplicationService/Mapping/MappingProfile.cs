using ApplicationService.DTOs;
using ApplicationService.DTOs.Person;
using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();            
            // Coach -> CoachDto
            CreateMap<Coach, CoachDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.Person.FirstName + " " + src.Person.LastName))
                .ForMember(dest => dest.ExperinceYears,
                           opt => opt.MapFrom(src => src.ExperienceYears))
                .ForMember(dest => dest.Specilization,
                           opt => opt.MapFrom(src => src.Specialization))
                .ForMember(dest => dest.CertificateNumber,
                           opt => opt.MapFrom(src => src.CertificateNumber))
                .ForMember(dest => dest.IsActive,
                           opt => opt.MapFrom(src => src.IsActive));
        }

    }
}
