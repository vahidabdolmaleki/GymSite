using ApplicationService.DTOs.Student;
using Core;
using Entities;

namespace ApplicationService.Interfaces
{
    public interface IStudentService
    {
        Task<ServiceResult<string>> RegisterAsync(StudentRegisterDto dto);
        Task<ServiceResult<string>> UpdateAsync(StudentUpdateDto dto);
        Task<ServiceResult<List<StudentDto>>> GetAllAsync(int? coachId = null);
        Task<ServiceResult<string>> DeactivateAsync(int id);
    }
}
