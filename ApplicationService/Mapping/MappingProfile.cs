using ApplicationService.DTOs;
using ApplicationService.DTOs.Person;
using ApplicationService.DTOs.WorkoutPlan;
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

            // Workout Mapping
            CreateMap<Workout, WorkoutDto>()
            .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.WorkoutSubCategory.Title))
            .ForMember(dest => dest.Media, opt => opt.MapFrom(src => src.Media));

            CreateMap<WorkoutCreateDto, Workout>();
            CreateMap<WorkoutUpdateDto, Workout>();

            CreateMap<WorkoutMedia, WorkoutMediaDto>();

            // ============================
            //       WorkoutPlan → DTO
            // ============================
            CreateMap<WorkoutPlan, WorkoutPlanDto>()
                .ForMember(dest => dest.Items,
                    opt => opt.MapFrom(src => src.Items));

            // ============================
            //    WorkoutPlanItem → DTO
            // ============================
            CreateMap<WorkoutPlanItem, WorkoutPlanItemDto>()
                .ForMember(dest => dest.WorkoutName,
                    opt => opt.MapFrom(src => src.Workout.Name));

            // ============================
            //     DTO → WorkoutPlan
            // ============================
            CreateMap<WorkoutPlanCreateDto, WorkoutPlan>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // در DB ساخته می‌شود

            // ============================
            //   DTO → WorkoutPlanItem
            // ============================
            CreateMap<WorkoutPlanItemCreateDto, WorkoutPlanItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.WorkoutPlanId, opt => opt.Ignore());

        }

    }
}
