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
    internal class GymClassRepository : GenericRepository<GymClass>, IGymClassRepository
    {
        private readonly GymDbContext _context;

        public GymClassRepository(GymDbContext context) : base(context)
        {
            _context = context;
        }

        public List<GymClass> GetAllWithDetails() =>
            _context.GymClasses
                .Include(c => c.Coach).ThenInclude(co => co.Person)
                .Include(c => c.Enrollments).ThenInclude(e => e.Student)
                .Include(c => c.Category)
                .OrderByDescending(c => c.StartAt)
                .ToList();

        public async Task<List<GymClass>> GetAllWithDetailsAsync() =>
            await _context.GymClasses
                .Include(c => c.Coach).ThenInclude(co => co.Person)
                .Include(c => c.Enrollments).ThenInclude(e => e.Student)
                .Include(c => c.Category)
                .OrderByDescending(c => c.StartAt)
                .ToListAsync();

        public List<GymClass> GetByCoach(int coachId) =>
            _context.GymClasses
                .Where(c => c.CoachId == coachId)
                .Include(c => c.Category)
                .OrderBy(c => c.StartAt)
                .ToList();

        public async Task<List<GymClass>> GetByCoachAsync(int coachId) =>
            await _context.GymClasses
                .Where(c => c.CoachId == coachId)
                .Include(c => c.Category)
                .OrderBy(c => c.StartAt)
                .ToListAsync();

        public List<GymClass> GetByStudent(int studentId) =>
            _context.GymClasses
                .Include(c => c.Enrollments)
                .Where(c => c.Enrollments.Any(e => e.StudentId == studentId))
                .Include(c => c.Category)
                .ToList();

        public async Task<List<GymClass>> GetByStudentAsync(int studentId) =>
            await _context.GymClasses
                .Include(c => c.Enrollments)
                .Where(c => c.Enrollments.Any(e => e.StudentId == studentId))
                .Include(c => c.Category)
                .ToListAsync();

        public List<GymClass> GetActiveClasses() =>
            _context.GymClasses
                .Where(c => c.EndAt > DateTime.Now)
                .OrderBy(c => c.StartAt)
                .ToList();

        public async Task<List<GymClass>> GetActiveClassesAsync() =>
            await _context.GymClasses
                .Where(c => c.EndAt > DateTime.Now)
                .OrderBy(c => c.StartAt)
                .ToListAsync();

        public List<GymClass> Search(string keyword) =>
            _context.GymClasses
                .Where(c => c.Title.Contains(keyword) || (c.Description ?? "").Contains(keyword))
                .Include(c => c.Category)
                .ToList();

        public async Task<List<GymClass>> SearchAsync(string keyword) =>
            await _context.GymClasses
                .Where(c => c.Title.Contains(keyword) || (c.Description ?? "").Contains(keyword))
                .Include(c => c.Category)
                .ToListAsync();
    }
}
