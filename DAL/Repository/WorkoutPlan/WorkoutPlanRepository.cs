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
    public class WorkoutPlanRepository : GenericRepository<WorkoutPlan>, IWorkoutPlanRepository
    {
        private readonly GymDbContext _gymDbContext;

        public WorkoutPlanRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<WorkoutPlan> GetByPersonId(int personId)
        {
            return _context.WorkoutPlans
                .Where(wp => wp.PersonId == personId)
                .OrderByDescending(wp => wp.StartDate)
                .ToList();
        }

        public async Task<List<WorkoutPlan>> GetByPersonIdAsync(int personId)
        {
            return await _context.WorkoutPlans
                .Where(wp => wp.PersonId == personId)
                .OrderByDescending(wp => wp.StartDate)
                .ToListAsync();
        }

        public List<WorkoutPlan> GetActivePlans(int personId)
        {
            return _context.WorkoutPlans
                .Where(wp => wp.PersonId == personId && (wp.EndDate == null || wp.EndDate > DateTime.UtcNow))
                .ToList();
        }

        public async Task<List<WorkoutPlan>> GetActivePlansAsync(int personId)
        {
            return await _context.WorkoutPlans
                .Where(wp => wp.PersonId == personId && (wp.EndDate == null || wp.EndDate > DateTime.UtcNow))
                .ToListAsync();
        }

        public WorkoutPlan? GetLatestPlan(int personId)
        {
            return _context.WorkoutPlans
                .Where(wp => wp.PersonId == personId)
                .OrderByDescending(wp => wp.StartDate)
                .FirstOrDefault();
        }

        public async Task<WorkoutPlan?> GetLatestPlanAsync(int personId)
        {
            return await _context.WorkoutPlans
                .Where(wp => wp.PersonId == personId)
                .OrderByDescending(wp => wp.StartDate)
                .FirstOrDefaultAsync();
        }


        public async Task<WorkoutPlan?> GetPlanWithItemsAsync(int id)
        {
            return await _context.WorkoutPlans
                .Include(p => p.Items)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<WorkoutPlan> GetPlansForPerson(int personId)
        {
            return _context.WorkoutPlans
                .Where(p => p.PersonId == personId)
                .Include(p => p.Items);
        }
    }
}
