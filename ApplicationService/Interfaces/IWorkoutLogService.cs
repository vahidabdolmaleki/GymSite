using ApplicationService.DTOs.WorkoutLog;
using Core;

namespace ApplicationService.Interfaces
{
    public interface IWorkoutLogService
    {
        Task<ServiceResult<int>> CreateAsync(WorkoutLogCreateDto dto);
        Task<ServiceResult<List<WorkoutLogDto>>> GetLogsForPersonAsync(int personId);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }

}
