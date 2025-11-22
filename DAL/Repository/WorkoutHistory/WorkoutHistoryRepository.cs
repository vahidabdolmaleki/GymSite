using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class WorkoutHistoryRepository : GenericRepository<WorkoutHistory>, IWorkoutHistoryRepository
    {
        private readonly GymDbContext _gymDbContext;

        public WorkoutHistoryRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<WorkoutHistory> GetByPersonId(int personId)
        {
            return _gymDbContext.WorkoutHistories
                .Include(wh => wh.WorkoutPlan)
                .Where(wh => wh.WorkoutPlan.PersonId == personId)
                .OrderByDescending(wh => wh.DoneAt)
                .ToList();
        }

        public async Task<List<WorkoutHistory>> GetByPersonIdAsync(int personId)
        {
            return await _gymDbContext.WorkoutHistories
                .Include(wh => wh.WorkoutPlan)
                .Where(wh => wh.WorkoutPlan.PersonId == personId)
                .OrderByDescending(wh => wh.DoneAt)
                .ToListAsync();
        }

        public List<WorkoutHistory> GetByWorkoutPlanId(int workoutPlanId)
        {
            return _gymDbContext.WorkoutHistories
                .Include(wh => wh.WorkoutPlan)
                .Where(wh => wh.WorkoutPlanId == workoutPlanId)
                .OrderByDescending(wh => wh.DoneAt)
                .ToList();
        }

        public async Task<List<WorkoutHistory>> GetByWorkoutPlanIdAsync(int workoutPlanId)
        {
            return await _gymDbContext.WorkoutHistories
                .Include(wh => wh.WorkoutPlan)
                .Where(wh => wh.WorkoutPlanId == workoutPlanId)
                .OrderByDescending(wh => wh.DoneAt)
                .ToListAsync();
        }

        public WorkoutHistory? GetLatestByPersonId(int personId)
        {
            return _gymDbContext.WorkoutHistories
                .Include(wh => wh.WorkoutPlan)
                .Where(wh => wh.WorkoutPlan.PersonId == personId)
                .OrderByDescending(wh => wh.DoneAt)
                .FirstOrDefault();
        }

        public async Task<WorkoutHistory?> GetLatestByPersonIdAsync(int personId)
        {
            return await _gymDbContext.WorkoutHistories
                .Include(wh => wh.WorkoutPlan)
                .Where(wh => wh.WorkoutPlan.PersonId == personId)
                .OrderByDescending(wh => wh.DoneAt)
                .FirstOrDefaultAsync();
        }
    }
}
