using ApplicationService.DTOs.Person;
using ApplicationService.Interfaces;
using AutoMapper;
using Core;
using DAL.UnitOfWork;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<PersonService> _logger;
        private readonly IJwtService _jwtService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string PERSON_CACHE_KEY = "persons_all";

        public PersonService(IUnitOfWork unitOfWork,IMapper mapper,IMemoryCache cache,ILogger<PersonService> logger, IJwtService jwtService,IHttpContextAccessor httpContextAccessor)
        {
            _uow = unitOfWork;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
            _jwtService = jwtService;
            _httpContextAccessor = httpContextAccessor;
        }

        // 📋 دریافت تمام کاربران
        public async Task<ServiceResults<PersonDto>> GetAllAsync()
        {
            const string cacheKey = "persons_all";

            if (_cache.TryGetValue(cacheKey, out IEnumerable<PersonDto>? cached))
            {
                return new ServiceResults<PersonDto>
                {
                    IsSuccess = true,
                    Data = cached,
                    Message = "داده‌ها از کش خوانده شدند."
                };
            }

            var persons = await _uow.PersonRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<PersonDto>>(persons);

            _cache.Set(cacheKey, dtos, TimeSpan.FromMinutes(10));

            return new ServiceResults<PersonDto>
            {
                IsSuccess = true,
                Data = dtos,
                Message = "داده‌ها با موفقیت بازیابی شدند."
            };
        }

        // 👤 دریافت کاربر بر اساس ID
        public async Task<ServiceResult<PersonDto>> GetByIdAsync(int id)
        {
            var person = await _uow.PersonRepository.FindByIdAsync(id);
            if (person == null)
                return new ServiceResult<PersonDto> { IsSuccess = false, Message = "کاربر یافت نشد." };

            var dto = _mapper.Map<PersonDto>(person);
            return new ServiceResult<PersonDto> { IsSuccess = true, Data = dto };
        }

        // 🧾 ثبت‌نام کاربر
        public async Task<ServiceResult<PersonDto>> RegisterAsync(PersonCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Password))
                return new ServiceResult<PersonDto> { IsSuccess = false, Message = "رمز عبور نمی‌تواند خالی باشد." };

            var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var person = _mapper.Map<Person>(dto);
            person.PasswordHash = hash;

            await _uow.PersonRepository.SaveAsync(person);
            await _uow.CommitAsync();

            return new ServiceResult<PersonDto>
            {
                IsSuccess = true,
                Message = "ثبت‌نام با موفقیت انجام شد.",
                Data = _mapper.Map<PersonDto>(person)
            };
        }

        // 🔐 ورود کاربر و ثبت دستگاه
        public async Task<ServiceResult<string>> LoginAsync(string username, string password, string deviceToken, string deviceType)
        {
            var person = await _uow.PersonRepository.FindByUsernameAsync(username);
            if (person == null || !BCrypt.Net.BCrypt.Verify(password, person.PasswordHash))
                return new ServiceResult<string> { IsSuccess = false, Message = "نام کاربری یا رمز عبور اشتباه است." };

            // ثبت یا به‌روزرسانی دستگاه
            var existingDevice = person.Devices.FirstOrDefault(d => d.PushNotificationId == deviceToken);
            if (existingDevice == null)
            {
                person.Devices.Add(new Device
                {
                    PushNotificationId = deviceToken,
                    DeviceType = deviceType,
                    PersonId = person.Id,
                    LastSeenAt = DateTime.UtcNow,
                    IsActive = true,
                    IP = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString()
                });
            }
            else
            {
                existingDevice.LastSeenAt = DateTime.UtcNow;
                existingDevice.IsActive = true;
            }

            await _uow.CommitAsync();

            // صدور توکن JWT
            var token = _jwtService.GenerateTokenForPerson(person);

            return new ServiceResult<string>
            {
                IsSuccess = true,
                Message = "ورود موفقیت‌آمیز.",
                Data = token
            };
        }

        // ✏️ ویرایش کاربر
        public async Task<ServiceResult<bool>> UpdateAsync(PersonUpdateDto dto)
        {
            var person = await _uow.PersonRepository.FindByIdAsync(dto.Id);
            if (person == null)
                return new ServiceResult<bool> { IsSuccess = false, Message = ExceptionMessage.DontFindUser, Data = false };

            if (!string.IsNullOrEmpty(dto.FirstName)) person.FirstName = dto.FirstName;
            if (!string.IsNullOrEmpty(dto.LastName)) person.LastName = dto.LastName;
            if (!string.IsNullOrEmpty(dto.Email)) person.Email = dto.Email;
            if (!string.IsNullOrEmpty(dto.PhoneNumber)) person.PhoneNumber = dto.PhoneNumber;
            person.IsActive = dto.IsActive;

            _uow.PersonRepository.Update(person);
            await _uow.CommitAsync();

            return new ServiceResult<bool> { IsSuccess = true, Message =ExceptionMessage.UpdateSuccessFully, Data = true };
        }

        // 🗑️ حذف کاربر
        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var person = await _uow.PersonRepository.FindByIdAsync(id);
            if (person == null)
                return new ServiceResult<bool> { IsSuccess = false, Message =ExceptionMessage.DontFindUser, Data = false };

            _uow.PersonRepository.Remove(person.Id);
            await _uow.CommitAsync();

            return new ServiceResult<bool> { IsSuccess = true, Message = ExceptionMessage.DeleteSuccessFully, Data = true };
        }
        // ثبت کاربر
        public async Task<ServiceResult<string>> RegisterAsync(PersonRegisterDto dto)
        {
            var result = new ServiceResult<string>();

            try
            {
                // 1️⃣ بررسی تکراری بودن نام کاربری
                var existing = await _uow.PersonRepository.FindByUsernameAsync(dto.Username);
                if (existing != null)
                {
                    result.IsSuccess = false;
                    result.Message = "نام کاربری از قبل وجود دارد.";
                    return result;
                }

                // 2️⃣ هش کردن رمز عبور
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

                // 3️⃣ ساخت کاربر جدید
                var person = new Person
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    FatherName = dto.FatherName,
                    NationalCode = dto.NationalCode,
                    BirthDate = dto.BirthDate,
                    Username = dto.Username,
                    PasswordHash = hashedPassword,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                    Education = dto.Education,
                    Bio = dto.Bio,
                    CreatedDate = DateTime.UtcNow,                    
                    IsActive = true,
                    PersonTypeId = dto.PersonTypeId
                };

                // 4️⃣ ثبت دستگاه کاربر (با IP)
                var device = new Device
                {
                    PushNotificationId = dto.PushNotificationId,
                    DeviceType = dto.DeviceType,
                    LastSeenAt = DateTime.UtcNow,
                    IP = dto.IP ?? _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
                    IsActive = true
                };

                person.Devices.Add(device);

                // 5️⃣ ذخیره در دیتابیس
                await _uow.PersonRepository.SaveAsync(person);
                await _uow.CommitAsync();

                // 6️⃣ پاسخ موفق
                return new ServiceResult<string> 
                {
                    IsSuccess = true,
                    Message = "ثبت‌نام با موفقیت انجام شد.",
                    Data = person.Username
                
                };
            }
            catch (Exception ex)
            {
                // 6️⃣ پاسخ خطا
                return new ServiceResult<string>
                {
                    IsSuccess = false,
                    Message = $"خطا در ثبت‌نام: {ex.Message}",
                    Data = null
                };                
            }

            
        }


    }
}
