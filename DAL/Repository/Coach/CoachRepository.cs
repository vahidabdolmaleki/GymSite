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
    public class CoachRepository : GenericRepository<Coach>, ICoachRepository
    {
        private readonly GymDbContext _gymDbContext;

        public CoachRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<Coach> GetAllWithDetails() =>
            _gymDbContext.Coaches
                .Include(c => c.Person)
                .Include(c => c.Classes)
                .OrderBy(c => c.Person.FirstName)
                .ToList();

        public async Task<List<Coach>> GetAllWithDetailsAsync() =>
            await _gymDbContext.Coaches
                .Include(c => c.Person)
                .Include(c => c.Classes)
                .OrderBy(c => c.Person.FirstName)
                .ToListAsync();

        public List<Coach> Search(string keyword) =>
            _gymDbContext.Coaches
                .Include(c => c.Person)
                .Where(c => c.Person.FirstName.Contains(keyword)
                         || c.Person.LastName.Contains(keyword)
                         || (c.Specialty ?? "").Contains(keyword))
                .ToList();

        public async Task<List<Coach>> SearchAsync(string keyword) =>
            await _gymDbContext.Coaches
                .Include(c => c.Person)
                .Where(c => c.Person.FirstName.Contains(keyword)
                         || c.Person.LastName.Contains(keyword)
                         || (c.Specialty ?? "").Contains(keyword))
                .ToListAsync();

        public List<GymClass> GetCoachClasses(int coachId) =>
            _gymDbContext.GymClasses
                .Include(g => g.Category)
                .Where(g => g.CoachId == coachId)
                .OrderByDescending(g => g.StartAt)
                .ToList();

        public async Task<List<GymClass>> GetCoachClassesAsync(int coachId) =>
            await _gymDbContext.GymClasses
                .Include(g => g.Category)
                .Where(g => g.CoachId == coachId)
                .OrderByDescending(g => g.StartAt)
                .ToListAsync();

        public int GetStudentCount(int coachId) =>
            _gymDbContext.ClassEnrollments
                .Include(e => e.GymClass)
                .Count(e => e.GymClass.CoachId == coachId);

        public async Task<int> GetStudentCountAsync(int coachId) =>
            await _gymDbContext.ClassEnrollments
                .Include(e => e.GymClass)
                .CountAsync(e => e.GymClass.CoachId == coachId);
    }
}
