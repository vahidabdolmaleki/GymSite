using ApplicationService.DTOs.Person;
using ApplicationService.Interfaces;
using AutoMapper;
using Core;
using DAL.UnitOfWork;
using Entities;
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
        private const string PERSON_CACHE_KEY = "persons_all";

        public PersonService(IUnitOfWork unitOfWork,IMapper mapper,IMemoryCache cache,ILogger<PersonService> logger, IJwtService jwtService)
        {
            _uow = unitOfWork;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
            _jwtService = jwtService;
        }
        public async Task<int> CreateAsync(PersonCreateDto dto)
        {
            try
            {
                // اعتبارسنجی با FluentValidation فرض می‌کنیم قبل از فراخوانی انجام شده ولی اینجا باز چک می‌کنیم
                // Unique checks:
                if (!string.IsNullOrEmpty(dto.Email) && _uow.PersonRepository.GetAllQueryable().Any(p => p.Email == dto.Email))
                    throw new InvalidOperationException("Email already in use.");

                if (!string.IsNullOrEmpty(dto.Username) && _uow.PersonRepository.GetAllQueryable().Any(p => p.Username == dto.Username))
                    throw new InvalidOperationException("Username already in use.");

                var person = _mapper.Map<Person>(dto);

                // هش رمز با BCrypt
                person.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

                _uow.PersonRepository.Save(person);
                await _uow.CommitAsync();

                // پاک کردن کش
                _cache.Remove(PERSON_CACHE_KEY);

                return person.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ExceptionMessage.CreateAsyncFailedFor, dto);
                throw;
            }
        }

        public async Task DeleteAsync(int Id)
        {
            try
            {
                _uow.PersonRoleRepostiory.Remove(Id);
                await _uow.CommitAsync();
                _cache.Remove(PERSON_CACHE_KEY);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ExceptionMessage.DeleteAsyncFeild + Id);
                throw;
            }
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            try
            {
                if (_cache.TryGetValue(PERSON_CACHE_KEY, out IEnumerable<PersonDto> cached))
                    return cached;

                // GetAllQueryable defined in your repo — use it to fetch data
                var entities = _uow.PersonRepository.GetAllQueryable().ToList();
                var dtos = _mapper.Map<IEnumerable<PersonDto>>(entities);

                _cache.Set(PERSON_CACHE_KEY, dtos, TimeSpan.FromMinutes(5));
                return dtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ExceptionMessage.GetAllAsyncFailed);
                throw;
            }
        }

        public async Task<PersonDto?> GetByIdAsync(int id)
        {
            try
            {
                var person = _uow.PersonRepository.Find(id);
                return person == null ? null : _mapper.Map<PersonDto>(person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Get By Id feild for {Id}",id);
                throw;
            }            
        }

        public async Task UpdateAsync(PersonUpdateDto dto)
        {
            try
            {
                var existing = _uow.PersonRepository.Find(dto.Id);
                if (existing == null) throw new KeyNotFoundException(ExceptionMessage.PersonNotFound);
                // Map only allowed feilds (or use mapper)
                existing.FirstName = dto.FirstName ?? existing.FirstName;
                existing.LastName = dto.LastName ?? existing.LastName;
                existing.Email = dto.Email ?? existing.Email;
                existing.PhoneNumber = dto.PhoneNumber ?? existing.PhoneNumber;
                existing.BirthDate = dto.BirthDate ?? existing.BirthDate;

                _uow.PersonRepository.Update(existing);
                await _uow.CommitAsync();
                _cache.Remove(PERSON_CACHE_KEY);
            }
            catch (Exception)
            {

            }
        }

        public async Task<string?> LoginAsync(PersonLoginDto Dto)
        {
            try
            {
                var person = _uow.PersonRepository.GetAll()
                    .FirstOrDefault(
                        p =>
                        (!string.IsNullOrEmpty(p.Username) && p.Username == Dto.Identifier) ||
                        (!string.IsNullOrEmpty(p.Email) && p.Email == Dto.Identifier) ||
                        (!string.IsNullOrEmpty(p.PhoneNumber) && p.PhoneNumber == Dto.Identifier)
                    );
                if (person == null) return null;
                
                var verified = BCrypt.Net.BCrypt.Verify(Dto.Password,person.PasswordHash);
                if (!verified) return null;

                // تولید توکن اگر نخواستیم میتونیم فقط Ok برگردونیم
                var token = _jwtService.GenerateTokenForPerson(person);
                return token;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"LoginAsync faild for {@Dto}",Dto);
                throw;
            }
        }

        public Task ChangePasswordAsync(int personId, string currentPassword, string newPassword)
        {
            try
            {
                 var person = _uow   
            }
            catch (Exception)
            {

            }
        }

        public Task SetPrimaryPictureAsync(int personId, int pictureId)
        {
            throw new NotImplementedException();
        }
    }
}
