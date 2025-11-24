using ApplicationService.Interfaces;
using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationService.Services
{
    public class WorkoutLogRepository : GenericRepository<WorkoutLog>, IWorkoutLogRepository
    {
        public WorkoutLogRepository(GymDbContext context) : base(context)
        {
        }

        public async Task<List<WorkoutLog>> GetByPersonAsync(int personId)
        {
            return await _context.WorkoutLogs
                .Include(x => x.Person)
                .Include(x => x.Workout)
                .Where(x => x.PersonId == personId)
                .OrderByDescending(x => x.PerformedAt)
                .ToListAsync();
        }
    }

}
