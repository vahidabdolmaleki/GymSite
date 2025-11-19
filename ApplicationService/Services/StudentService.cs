using ApplicationService.DTOs.Student;
using ApplicationService.Interfaces;
using Core;
using DAL.UnitOfWork;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationService.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;

        public StudentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // 🟢 ثبت شاگرد جدید
        public async Task<ServiceResult<string>> RegisterAsync(StudentRegisterDto dto)
        {
            try
            {
                var person = await _uow.PersonRepository.FindByIdAsync(dto.PersonId);
                if (person == null)
                    return new ServiceResult<string>()
                    {
                        IsSuccess = false,
                        Data = ExceptionMessage.DontFindUser,
                        Message = ExceptionMessage.DontFindUser
                    };

                var student = new Student
                {
                    PersonId = dto.PersonId,
                    CoachId = dto.CoachId,
                    Level = dto.Level,
                    Goal = dto.Goal,
                    RegisteredAt = DateTime.UtcNow,
                    IsActive = true
                };

                await _uow.StudentRepository.SaveAsync(student);
                await _uow.CommitAsync();

                return new ServiceResult<string>()
                { 
                    IsSuccess = true,
                    Data = student.Id.ToString(),
                    Message = ExceptionMessage.CreateStudentSuccessfully
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<string>()
                { 
                    IsSuccess =false,
                    Data = ExceptionMessage.CreateStudentFeild,
                    Message = ex.Message
                };
            }
        }

        // 🟡 ویرایش اطلاعات شاگرد
        public async Task<ServiceResult<string>> UpdateAsync(StudentUpdateDto dto)
        {
            try
            {
                var student = await _uow.StudentRepository.FindAsync(dto.Id);
                if (student == null)
                    return new ServiceResult<string>()
                    {
                        IsSuccess = false,
                        Message =ExceptionMessage.DontFindStudent,
                        Data = null
                    };

                student.CoachId = dto.CoachId;
                student.Level = dto.Level;
                student.Goal = dto.Goal;
                student.IsActive = dto.IsActive;

                _uow.StudentRepository.Update(student);
                await _uow.CommitAsync();

                return new ServiceResult<string>()
                { 
                    IsSuccess = true,
                    Data =student.Id.ToString(),
                    Message = ExceptionMessage.UpdateStudentSuccessfully
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<string>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = ExceptionMessage.UpdateStudentFeild
                };
            }
        }

        // 🟣 دریافت لیست شاگردان (اختیاری: فیلتر براساس CoachId)
        public async Task<ServiceResult<List<StudentDto>>> GetAllAsync(int? coachId = null)
        {
            try
            {
                List<Student> students;

                if (coachId.HasValue)
                    students = await _uow.StudentRepository.GetByCoachIdAsync(coachId.Value);
                else
                    students = await _uow.StudentRepository.GetAllQueryable()
                        .Include(s => s.Person)
                        .Include(s => s.Coach)
                            .ThenInclude(c => c.Person)
                        .ToListAsync();

                var dtoList = students.Select(s => new StudentDto
                {
                    Id = s.Id,
                    FullName = $"{s.Person.FirstName} {s.Person.LastName}",
                    Level = s.Level,
                    Goal = s.Goal,
                    CoachName = s.Coach != null ? $"{s.Coach.Person.FirstName} {s.Coach.Person.LastName}" : "-",
                    IsActive = s.IsActive
                }).ToList();

                return new ServiceResult<List<StudentDto>>()
                { 
                    Data= dtoList,
                    Message = ExceptionMessage.ListStudentSuccessfullyRetrieved,
                    IsSuccess = false
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<List<StudentDto>>
                { 
                    IsSuccess = false,
                    Data = null,
                    Message =$"{ExceptionMessage.FeildListStudentRetrieved}: {ex.Message}"
                };
            }
        }

        // 🔵 حذف منطقی (Deactivate)
        public async Task<ServiceResult<string>> DeactivateAsync(int id)
        {
            try
            {
                var student = await _uow.StudentRepository.FindAsync(id);
                if (student == null)
                    return new ServiceResult<string>()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = ExceptionMessage.DontFindStudent
                    };

                student.IsActive = false;
                _uow.StudentRepository.Update(student);
                await _uow.CommitAsync();

                return new ServiceResult<string>() 
                {
                    IsSuccess = true,
                    Message = ExceptionMessage.StudentSuccessfullyDeactived,
                    Data = student.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<string>()
                { 
                    Data = ex.Message ,
                    IsSuccess = false,
                    Message = ExceptionMessage.DeleteStudentFeild
                };
            }
        }
    }
}
