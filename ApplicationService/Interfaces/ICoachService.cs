using ApplicationService.DTOs;
using ApplicationService.DTOs.Common;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface ICoachService
    {
        Task<ServiceResult<CoachDto>> GetByIdAsync(int Id);
        Task<ServiceResults<CoachDto>> GetAllAsync();
        Task<ServiceResult<string>> CreateAsync(CoachCreateDto dto);
        Task<ServiceResult<bool>> UpdateAsync(CoachUpdateDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
        Task<ServiceResults<CoachDto>> GetStudentAsync(int coachId);
        Task<ServiceResult<PagedResultDto<CoachDto>>> SearchAsync(string? name, string? specialization, int page, int pageSize);
    }
}
