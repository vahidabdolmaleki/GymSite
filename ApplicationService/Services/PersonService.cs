using ApplicationService.DTOs.Person;
using ApplicationService.DTOs.Token;
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
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
                    Message = ExceptionMessage.DataCouldNotBeReadFromCache
                };
            }

            var persons = await _uow.PersonRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<PersonDto>>(persons);

            _cache.Set(cacheKey, dtos, TimeSpan.FromMinutes(10));

            return new ServiceResults<PersonDto>
            {
                IsSuccess = true,
                Data = dtos,
                Message = ExceptionMessage.DataWasSuccessfullyRecoverd
            };
        }

        // 👤 دریافت کاربر بر اساس ID
        public async Task<ServiceResult<PersonDto>> GetByIdAsync(int id)
        {
            var person = await _uow.PersonRepository.FindByIdAsync(id);
            if (person == null)
                return new ServiceResult<PersonDto> { IsSuccess = false, Message = ExceptionMessage.DontFindUser };

            var dto = _mapper.Map<PersonDto>(person);
            return new ServiceResult<PersonDto> { IsSuccess = true, Data = dto };
        }



        // 🔐 ورود کاربر و ثبت دستگاه
    public async Task<ServiceResult<TokenResponseDto>> LoginAsync(LoginRequestDto dto)
{
    var result = new ServiceResult<TokenResponseDto>();

    var person = _uow.PersonRepository
    .GetAllWithDevices()
    .FirstOrDefault(p => p.Username == dto.UsernameOrIdentifier || p.PhoneNumber == dto.UsernameOrIdentifier);


    if (person == null || !BCrypt.Net.BCrypt.Verify(dto.Password, person.PasswordHash))
    {
        result.IsSuccess = false;
                result.Message = ExceptionMessage.UsernameOrPasswordIsInvalid;
        return result;
    }

    // تولید Access و Refresh Token
    var accessToken = _jwtService.GenerateTokenForPerson(person);
    var refreshToken = _jwtService.GenerateRefreshToken();

    // ذخیره در Device
    var device = person.Devices.FirstOrDefault(d => d.PushNotificationId == dto.PushNotificationId);
    if (device == null)
    {
        device = new Device
        {
            PushNotificationId = dto.PushNotificationId,
            DeviceType = dto.DeviceType,
            IP = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
            LastSeenAt = DateTime.UtcNow,
            IsActive = true,
            RefreshToken = refreshToken,
            RefreshTokenExpiry = DateTime.UtcNow.AddDays(7),
            PersonId = person.Id
        };
        await _uow.DeviceRepository.SaveAsync(device);
    }
    else
    {
        device.RefreshToken = refreshToken;
        device.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
        device.LastSeenAt = DateTime.UtcNow;
        await _uow.DeviceRepository.UpdateAsync(device);
    }

    await _uow.CommitAsync();

    result.IsSuccess = true;
    result.Data = new TokenResponseDto
    {
        AccessToken = accessToken,
        RefreshToken = refreshToken
    };
    result.Message = ExceptionMessage.LoginSuccessFully;

    return result;
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
                // 1️⃣ بررسی تکراری بودن کاربر
                var existingUser = _uow.PersonRepository.GetAll()
                    .FirstOrDefault(p =>
                        p.Username == dto.Username ||
                        p.Email == dto.Email ||
                        p.PhoneNumber == dto.PhoneNumber);

                if (existingUser != null)
                {
                    result.IsSuccess = false;
                    result.Message = ExceptionMessage.YouCantInsertDuplicateUser ;
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
                    IsActive = false, // تا وقتی تأیید نشده
                    PersonTypeId = dto.PersonTypeId
                };

                // 4️⃣ ثبت دستگاه کاربر
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

                // 6️⃣ ساخت کد تأیید
                var verificationCode = new VerificationCode
                {
                    PersonId = person.Id,
                    Code = new Random().Next(100000, 999999).ToString(),
                    ExpireAt = DateTime.UtcNow.AddMinutes(5)
                };

                await _uow.VerificationCodes.SaveAsync(verificationCode);
                await _uow.CommitAsync();

                // 7️⃣ پاسخ موفق
                result.IsSuccess = true;
                result.Message = ExceptionMessage.RegisterSuccessfullyDoPleaseInsertComfirmCode;
                result.Data = person.Username;

                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"{ExceptionMessage.RegisterFeild}{ex.Message}";
                return result;
            }
        }


        public async Task<ServiceResult<bool>> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            try
            {
                var Result = new ServiceResult<bool>();
                var person = await _uow.PersonRepository.FindByUsernameAsync(dto.UsernameOrPhone);
                if (person == null)
                {
                    Result.IsSuccess = false;
                    Result.Message = ExceptionMessage.DontFindUser;
                    return Result;
                }
                // تولید کد
                var code = new Random().Next(100000,999999).ToString();

                var verification = new VerificationCode
                {
                    PersonId = person.Id,
                    Code = code,
                    ExpireAt = DateTime.UtcNow.AddMinutes(5),
                    IsUsed = false,
                    IsActive = true
                };

                await _uow.VerificationCodes.SaveAsync(verification);
                await _uow.CommitAsync();

                // TODO: impiliment Send Email or SMS Service

                return new ServiceResult<bool> 
                {
                    IsSuccess = true,
                    Data = true,
                    Message = ExceptionMessage.SendVerificationCodeCompelete
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<bool>
                {
                    IsSuccess = false,
                    Message = ExceptionMessage.ForgotPasswrodFeild + ex.Message,
                    Data = false

                };
            }
        }

        public async Task<ServiceResult<bool>> VerifyCodeAsync(VerifyCodeDto dto)
        {
            try
            {
                // 1. پیدا کردن کاربر بر اساس username یا phone
                var person = await _uow.PersonRepository.FindByUsernameAsync(dto.UsernameOrPhone);
                if (person == null) 
                {
                    return new ServiceResult<bool> { IsSuccess = false, Data = false ,Message= ExceptionMessage.DontFindUser};
                }
                // 2. پیدا کردن کد فعال برای شخص

                var code = await _uow.VerificationCodes.GetActiveCodeAsync(person.Id,dto.Code);

                if (code == null)
                {
                    return new ServiceResult<bool> { IsSuccess = false, Data=false,Message = ExceptionMessage.CodeExpiredOrNotValid};
                }

                // 3. علامت‌گذاری کد به عنوان استفاده‌شده
                code.IsUsed = true;
                // (در صورت تمایل می‌توان تاریخ استفاده/لاگ هم ثبت کرد)

                // 4. فعال کردن حساب کاربری
                person.IsActive = true;

                // 5. در صورت نیاز: حذف یا غیرفعال‌سازی بقیه کدهای فعال قدیمی
                var otherCodes = (await _uow.VerificationCodes
                    .GetAllActiveByPersonAsync(person.Id))
                    .Where(v => v.Id != code.Id);

                foreach (var c in otherCodes)
                {
                    c.IsUsed = true;
                }
                await _uow.CommitAsync();

                return new ServiceResult<bool> 
                {
                    IsSuccess = true,
                    Data = true,
                    Message = ExceptionMessage.codeVrified
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<bool> 
                {
                    Data = false, IsSuccess = false,
                    Message = ExceptionMessage.VerifyCodeError + " "+ ex.Message
                };
            }
        }
        //ToDo: گام بعدی رو هم بریم (ارسال واقعی SMS یا Email برای کد تأیید، مثلاً با Kavenegar یا SMTP) یا فعلاً بمونیم روی ساختار پایه API‌ها؟
        public async Task<ServiceResult<bool>> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var result = new ServiceResult<bool>();

            var person = await _uow.PersonRepository
                .FindByUsernameOrPhoneAsync(dto.UsernameOrPhone);

            if (person == null)
            {
                result.IsSuccess = false;
                result.Message = ExceptionMessage.DontFindUser;
                return result;
            }

            var code = await _uow.VerificationCodes
                .GetActiveCodeAsync(person.Id, dto.Code);

            if (code == null || code.IsUsed || code.ExpireAt < DateTime.UtcNow)
            {
                result.IsSuccess = false;
                result.Message = ExceptionMessage.CodeIsNotValid;
                return result;
            }

            // تغییر رمز
            person.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);

            code.IsUsed = true;
            await _uow.CommitAsync();

            result.IsSuccess = true;
            result.Data = true;
            result.Message = ExceptionMessage.PasswordSuccessfullyChanged;
            return result;
        }
        public async Task<ServiceResult<TokenResponseDto>> RefreshTokenAsync(RefreshTokenDto dto)
        {
            var result = new ServiceResult<TokenResponseDto>();

            try
            {
                var principal = _jwtService.GetPrincipalFromExpiredToken(dto.AccessToken);
                if (principal == null)
                {
                    result.IsSuccess = false;
                    result.Message =ExceptionMessage.TokenIsNotValid;
                    return result;
                }

                var personId = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

                var device = _uow.DeviceRepository
                    .GetAll()
                    .FirstOrDefault(d => d.PersonId == personId && d.RefreshToken == dto.RefreshToken);

                if (device == null || device.RefreshTokenExpiry < DateTime.UtcNow)
                {
                    result.IsSuccess = false;
                    result.Message = ExceptionMessage.RefeshTokenOrExpiredToken;
                    return result;
                }

                // تولید توکن جدید
                var person = _uow.PersonRepository.Find(personId);
                var newAccessToken = _jwtService.GenerateTokenForPerson(person);
                var newRefreshToken = _jwtService.GenerateRefreshToken();

                // ذخیره Refresh Token جدید
                device.RefreshToken = newRefreshToken;
                device.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
                await _uow.DeviceRepository.UpdateAsync(device);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Data = new TokenResponseDto
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken
                };
                result.Message = ExceptionMessage.NewTokenCreated;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"{ExceptionMessage.FeildUpdatetoken} {ex.Message}";
            }

            return result;
        }
        // todo  این وب سرویس بدرستی کار نمیکنه پروژه که تموم شد برای این وقت بزار مشکلش رو رفع کن
        public async Task<ServiceResult<bool>> LogoutAsync(string accessToken)
        {
            var result = new ServiceResult<bool>();

            try
            {
                // ۱️⃣ استخراج اطلاعات کاربر از JWT
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(accessToken);
                var personIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;

                if (string.IsNullOrEmpty(personIdClaim) || !int.TryParse(personIdClaim, out int personId))
                {
                    result.IsSuccess = false;
                    result.Message = ExceptionMessage.TokenIsNotValid;
                    return result;
                }

                // ۲️⃣ پیدا کردن دستگاه مرتبط
                var device = _uow.DeviceRepository.GetAll()
                    .FirstOrDefault(d => d.PersonId == personId && d.IsActive);

                if (device == null)
                {
                    result.IsSuccess = false;
                    result.Message = ExceptionMessage.DontFindDeviceForExit;
                    return result;
                }

                // ۳️⃣ باطل‌سازی RefreshToken و غیرفعال کردن دستگاه
                device.IsActive = false;
                device.RefreshToken = null;
                device.LastSeenAt = DateTime.UtcNow;

                _uow.DeviceRepository.Update(device);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Message = ExceptionMessage.ExitSuccessfully;
                result.Data = true;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"{ExceptionMessage.ExitFeild} {ex.Message}";
                return result;
            }
        }


    }
}
