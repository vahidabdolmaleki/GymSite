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
            CreateMap<Coach, CoachDto>().ReverseMap();            
        }

    }
}
