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

        public Task<ServiceResults<PersonDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<PersonDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<PersonDto>> RegisterAsync(PersonCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
