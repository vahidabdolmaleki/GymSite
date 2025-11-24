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
    public class WorkoutLogRepository : GenericRepository<WorkoutLog>, IWorkoutLogRepository
    {
        private readonly GymDbContext _gymDbContext;

        public WorkoutLogRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<WorkoutLog> GetByPersonId(int personId)
        {
            return _context.WorkoutLogs
                .Include(wl => wl.Workout)
                .Where(wl => wl.PersonId == personId)
                .OrderByDescending(wl => wl.PerformedAt)
                .ToList();
        }

        public async Task<List<WorkoutLog>> GetByPersonIdAsync(int personId)
        {
            return await _context.WorkoutLogs
                .Include(wl => wl.Workout)
                .Where(wl => wl.PersonId == personId)
                .OrderByDescending(wl => wl.PerformedAt)
                .ToListAsync();
        }

        public List<WorkoutLog> GetByWorkoutId(int workoutId)
        {
            return _context.WorkoutLogs
                .Include(wl => wl.Person)
                .Where(wl => wl.WorkoutId == workoutId)
                .OrderByDescending(wl => wl.PerformedAt)
                .ToList();
        }

        public async Task<List<WorkoutLog>> GetByWorkoutIdAsync(int workoutId)
        {
            return await _context.WorkoutLogs
                .Include(wl => wl.Person)
                .Where(wl => wl.WorkoutId == workoutId)
                .OrderByDescending(wl => wl.PerformedAt)
                .ToListAsync();
        }

        public bool HasCompletedWorkout(int personId, int workoutId, DateTime date)
        {
            return _context.WorkoutLogs
                .Any(wl => wl.PersonId == personId && wl.WorkoutId == workoutId && wl.PerformedAt.Date == date.Date && wl.IsCompleted);
        }

        public async Task<bool> HasCompletedWorkoutAsync(int personId, int workoutId, DateTime date)
        {
            return await _context.WorkoutLogs
                .AnyAsync(wl => wl.PersonId == personId && wl.WorkoutId == workoutId && wl.PerformedAt.Date == date.Date && wl.IsCompleted);
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
