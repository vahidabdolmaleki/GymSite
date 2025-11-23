using DAL.Repository.GenericRepository;
using Entities;

namespace DAL.Repository.WorkoutPlanItemRepo
{
    public interface IWorkoutPlanItemRepository : IGenericRepository<WorkoutPlanItem>
    {
        Task<WorkoutPlanItem?> GetFullItemAsync(int id);
        Task<List<WorkoutPlanItem>> GetByPlanIdAsync(int planId);
    }
}
