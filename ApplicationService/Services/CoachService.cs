using ApplicationService.DTOs;
using ApplicationService.DTOs.Common;
using ApplicationService.Interfaces;
using AutoMapper;
using Core;
using DAL.Context;
using DAL.Repository.GenericRepository;
using DAL.UnitOfWork;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApplicationService.Services
{
    public class CoachService : ICoachService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CoachService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // 📋 دریافت همه مربی‌ها
        public async Task<ServiceResults<CoachDto>> GetAllAsync()
        {
            var result = new ServiceResults<CoachDto>();

            try
            {
                var coaches = await _uow.CoachRepository.GetAllQueryable()
                    .Include(c => c.Person)
                    .ToListAsync();
                //List<CoachDto> coachDtos = FillCoaches(coaches);
                result.Data = _mapper.Map<IEnumerable<CoachDto>>(coaches);
                result.IsSuccess = true;
                result.Message = ExceptionMessage.MasterListSuccessfullyRetrieved;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"{ExceptionMessage.MasterListFeild} {ex.Message}";
            }

            return result;
        }

        private static List<CoachDto> FillCoaches(List<Coach> coaches)
        {
            List<CoachDto> coachDtos = new List<CoachDto>();
            for (int i = 0; i < coaches.Count; i++)
            {
                CoachDto coachDto = new CoachDto()
                {
                    Id = coaches[i].Id,
                    CertificateNumber = coaches[i].CertificateNumber,
                    ExperinceYears = coaches[i].ExperienceYears,
                    FullName = coaches[i].Person.FirstName + " " + coaches[i].Person.LastName,
                    Specilization = coaches[i].CertificateNumber,
                    IsActive = coaches[i].IsActive,
                };
                coachDtos.Add(coachDto);
            }

            return coachDtos;
        }

        // 🔍 دریافت مربی با شناسه
        public async Task<ServiceResult<CoachDto>> GetByIdAsync(int id)
        {
            var result = new ServiceResult<CoachDto>();

            try
            {
                var coach = await _uow.CoachRepository.FindAsync(id);
                if (coach == null)
                {
                    result.IsSuccess = false;
                    result.Message = ExceptionMessage.CoachNotFound;
                    return result;
                }
                
                    //CoachDto coachDto = new CoachDto()
                    //{
                    //    Id = coach.Id,
                    //    CertificateNumber = coach.CertificateNumber,
                    //    ExperinceYears = coach.ExperienceYears,
                    //    FullName = coach.Person.FirstName + " " + coach.Person.LastName,
                    //    Specilization = coach.CertificateNumber,
                    //    IsActive = coach.IsActive,
                    //};
                
                result.Data = _mapper.Map<CoachDto>(coach);
                result.IsSuccess = true;
                result.Message = ExceptionMessage.CoachInformationSuccessfullyRetieved;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"{ExceptionMessage.CoachInformationFeild}{ex.Message}";
            }
            return result;
        }

        // ➕ افزودن مربی جدید
        public async Task<ServiceResult<string>> CreateAsync(CoachCreateDto dto)
        {
            var result = new ServiceResult<string>();

            try
            {
                // بررسی وجود شخص در سیستم
                var person = await _uow.PersonRepository.FindAsync(dto.PersonId);
                if (person == null)
                {
                    result.IsSuccess = false;
                    result.Message = "شناسه شخص نامعتبر است.";
                    return result;
                }

                // بررسی تکراری بودن Coach برای PersonId
                var exists = _uow.CoachRepository.GetAll().Any(c => c.PersonId == dto.PersonId);
                if (exists)
                {
                    result.IsSuccess = false;
                    result.Message = "این شخص قبلاً به‌عنوان مربی ثبت شده است.";
                    return result;
                }

                var coach = new Coach
                {
                    PersonId = dto.PersonId,
                    Specialization = dto.Specialition,
                    ExperienceYears = dto.ExperienceYears,
                    CertificateNumber = dto.CertificateNumber,
                    IsActive = true
                };

                await _uow.CoachRepository.SaveAsync(coach);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Message = "مربی جدید با موفقیت ثبت شد.";
                result.Data = coach.Id.ToString();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"خطا در ثبت مربی جدید: {ex.Message}";
            }

            return result;
        }

        // ✏️ ویرایش اطلاعات مربی
        public async Task<ServiceResult<bool>> UpdateAsync(CoachUpdateDto dto)
        {
            var result = new ServiceResult<bool>();

            try
            {
                var coach = await _uow.CoachRepository.FindAsync(dto.PersonId);
                if (coach == null)
                {
                    result.IsSuccess = false;
                    result.Message = "مربی یافت نشد.";
                    return result;
                }

                coach.Specialization = dto.Specilization ?? coach.Specialization;
                coach.ExperienceYears = dto.ExperinceYears ?? coach.ExperienceYears;
                coach.CertificateNumber = dto.CertificateNumber ?? coach.CertificateNumber;
                if (dto.IsActive.HasValue) coach.IsActive = dto.IsActive.Value;

                await _uow.CoachRepository.UpdateAsync(coach);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Message = "اطلاعات مربی با موفقیت ویرایش شد.";
                result.Data = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"خطا در ویرایش اطلاعات مربی: {ex.Message}";
                result.Data = false;
            }

            return result;
        }

        // 🗑️ حذف مربی
        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var result = new ServiceResult<bool>();

            try
            {
                var coach = await _uow.CoachRepository.FindAsync(id);
                if (coach == null)
                {
                    result.IsSuccess = false;
                    result.Message = "مربی یافت نشد.";
                    return result;
                }

                await _uow.CoachRepository.RemoveAsync(id);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Message = "مربی با موفقیت حذف شد.";
                result.Data = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"خطا در حذف مربی: {ex.Message}";
                result.Data = false;
            }

            return result;
        }

        // 👨‍🎓 دریافت لیست شاگردهای یک مربی
        public async Task<ServiceResults<CoachDto>> GetStudentAsync(int coachId)
        {
            var result = new ServiceResults<CoachDto>();

            try
            {
                var coach = await _uow.CoachRepository.GetAllQueryable()
                    .Include(c => c.Students)
                    .ThenInclude(s => s.Person)
                    .FirstOrDefaultAsync(c => c.Id == coachId);

                if (coach == null)
                {
                    result.IsSuccess = false;
                    result.Message = ExceptionMessage.CoachNotFound;
                    return result;
                }

                result.Data = new List<CoachDto>
                {
                    new CoachDto
                    {
                        Id = coach.Id,
                        FullName = $"{coach.Person.FirstName} {coach.Person.LastName}",
                        Specilization = coach.Specialization,
                        ExperinceYears = coach.ExperienceYears,
                        IsActive = coach.IsActive
                    }
                };

                result.IsSuccess = true;
                result.Message = $"تعداد {coach.Students.Count} شاگرد برای مربی یافت شد.";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"{ExceptionMessage.GetStudentFeild}{ex.Message}";
            }

            return result;
        }

        public async Task<ServiceResult<PagedResultDto<CoachDto>>> SearchAsync(string? name,string? specialization,int page = 1,int pageSize = 10)
        {
            var result = new ServiceResult<PagedResultDto<CoachDto>>();

            try
            {
                var query = _uow.CoachRepository.GetAllQueryable()
                    .Include(c => c.Person)
                    .AsQueryable();

                // فیلتر بر اساس نام
                if (!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(c =>
                        c.Person.FirstName.Contains(name) ||
                        c.Person.LastName.Contains(name));
                }

                // فیلتر بر اساس تخصص
                if (!string.IsNullOrWhiteSpace(specialization))
                {
                    query = query.Where(c => c.Specialization.Contains(specialization));
                }

                // محاسبه صفحه‌بندی
                var totalCount = await query.CountAsync();
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var items = await query
                    .OrderBy(c => c.Person.FirstName)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                result.IsSuccess = true;
                result.Message = ExceptionMessage.SerachSuccessfully;

                result.Data = new PagedResultDto<CoachDto>
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    Items = _mapper.Map<IEnumerable<CoachDto>>(items)
                };
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"{ExceptionMessage.SerachFeild} {ex.Message}";
            }

            return result;
        }


    }
    

}
