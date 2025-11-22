using ApplicationService.DTOs.WorkoutPlan;
using Core;

namespace ApplicationService.Interfaces
{
    public interface IWorkoutPlanService
    {
        Task<ServiceResult<int>> CreateAsync(WorkoutPlanCreateDto dto);
        Task<ServiceResult<WorkoutPlanDto>> GetByIdAsync(int id);
        Task<ServiceResults<WorkoutPlanDto>> GetForPersonAsync(int personId);
        Task<ServiceResult<bool>> UpdateAsync(int id, WorkoutPlanCreateDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }

}
