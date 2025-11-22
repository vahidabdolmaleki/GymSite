using Core;

namespace ApplicationService.Interfaces
{
    public interface IWorkoutService
    {
        Task<ServiceResult<WorkoutDto>> CreateAsync(WorkoutCreateDto dto);
        Task<ServiceResult<WorkoutDto>> UpdateAsync(WorkoutUpdateDto dto);
        Task<ServiceResult<WorkoutDto>> GetByIdAsync(int id);
        Task<ServiceResults<WorkoutDto>> GetAllAsync();
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}
