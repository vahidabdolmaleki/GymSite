using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.WorkoutPlanItemRepo
{
    public class WorkoutPlanItemRepository : GenericRepository<WorkoutPlanItem>, IWorkoutPlanItemRepository
    {
        public WorkoutPlanItemRepository(GymDbContext context) : base(context)
        {
        }

        // دریافت آیتم به همراه Workout
        public async Task<WorkoutPlanItem?> GetFullItemAsync(int id)
        {
            return await _context.WorkoutPlanItems
                .Include(i => i.Workout)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        // دریافت آیتم‌های یک برنامه
        public async Task<List<WorkoutPlanItem>> GetByPlanIdAsync(int planId)
        {
            return await _context.WorkoutPlanItems
                .Include(i => i.Workout)
                .Where(i => i.WorkoutPlanId == planId)
                .ToListAsync();
        }
    }
}
