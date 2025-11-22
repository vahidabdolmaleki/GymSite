using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;

namespace DAL.Repository.WorkoutPlanItemRepo
{
    public class WorkoutPlanItemRepository : GenericRepository<WorkoutPlanItem>, IWorkoutPlanItemRepository
    {
        public WorkoutPlanItemRepository(GymDbContext context) : base(context)
        {
        }
    }
}
