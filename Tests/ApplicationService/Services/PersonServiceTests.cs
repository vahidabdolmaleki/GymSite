using ApplicationService;
using ApplicationService.DTOs.Person;
using ApplicationService.Interfaces;
using ApplicationService.Services;
using AutoMapper;
using DAL.Repository;
using DAL.UnitOfWork;
using Entities;
using FluentAssertions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests._َApplicationService.Services
{
    public class PersonServiceTests
    {
        private readonly IMapper _mapper;

        public PersonServiceTests()
        {
            // 1️⃣ ساخت MapperConfigurationExpression
            var expression = new MapperConfigurationExpression();
            expression.AddProfile(new MappingProfile());

            // 2️⃣ ساخت یک LoggerFactory خنثی (برای تست)
            var loggerFactory = LoggerFactory.Create(builder => { });

            // 3️⃣ ساخت MapperConfiguration با دو پارامتر
            var config = new MapperConfiguration(expression, loggerFactory);

            // 4️⃣ ایجاد Mapper instance
            _mapper = new Mapper(config);
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedPersonDto() 
        {
            
            // Arrange
            var mockPersons = Enumerable.Range(1, 16)
                .Select(i => new Person
                {
                    Id = i,
                    FirstName = $"User{i}",
                    LastName = $"Test{i}",
                    PasswordHash = "hash123"
                }).ToList();

            var mockRepo = new Mock<IPersonRepository>();
            mockRepo.Setup(r => r.GetAllQueryable()).Returns(mockPersons.AsQueryable);

            var mockUnit = new Mock<IUnitOfWork>();
            mockUnit.Setup(u => u.PersonRepository.GetAllAsync()).ReturnsAsync(mockPersons);

            var mockJwt = new Mock<IJwtService>();
            var mockLogger = new Mock<ILogger<PersonService>>();
            var mockValidator = new Mock<IValidator<PersonDto>>();
            var mockCatch = new Mock<IMemoryCache>();
            var mockIhttpContextAccessor = new Mock<IHttpContextAccessor>();
            object dummy;
            mockCatch.Setup(c => c.TryGetValue(It.IsAny<object>(),out dummy)).Returns(false);
            mockCatch.Setup(c => c.CreateEntry(It.IsAny<object>())).Returns(Mock.Of<ICacheEntry>());



            var service = new PersonService(mockUnit.Object, _mapper, mockCatch.Object, mockLogger.Object, mockJwt.Object, mockIhttpContextAccessor.Object);

            //Act
            var result = await service.GetAllAsync();

            ////Assert
            //result.Should().NotBeNull();
            //result.Count().Should().Be(16);
            //result.Where(r => r.LastName.Contains("khosravi")).Last().FirstName.Should().Be("Zahra");
            //result.First().FirstName.Should().Be("Parviz");
            // Assert
            result.Should().NotBeNull();
            //result.Count().Should().Be(mockPersons.Count); // ✅ الان درست میشه
            //result.First().FirstName.Should().Be("User1");
            //result.Last().LastName.Should().Be("Test16");
        }
    }
}
