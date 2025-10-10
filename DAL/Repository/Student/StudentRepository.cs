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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly GymDbContext _gymDbContext;

        public StudentRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<Student> GetAllWithDetails() =>
            _context.Students
                .Include(s => s.Person)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.GymClass)
                .OrderByDescending(s => s.RegisteredAt)
                .ToList();

        public async Task<List<Student>> GetAllWithDetailsAsync() =>
            await _context.Students
                .Include(s => s.Person)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.GymClass)
                .OrderByDescending(s => s.RegisteredAt)
                .ToListAsync();

        public List<Student> Search(string keyword) =>
            _context.Students
                .Include(s => s.Person)
                .Where(s =>
                    s.Person.FirstName.Contains(keyword) ||
                    s.Person.LastName.Contains(keyword) ||
                    (s.Person.NationalCode ?? "").Contains(keyword) ||
                    (s.Person.PhoneNumber ?? "").Contains(keyword))
                .ToList();

        public async Task<List<Student>> SearchAsync(string keyword) =>
            await _context.Students
                .Include(s => s.Person)
                .Where(s =>
                    s.Person.FirstName.Contains(keyword) ||
                    s.Person.LastName.Contains(keyword) ||
                    (s.Person.NationalCode ?? "").Contains(keyword) ||
                    (s.Person.PhoneNumber ?? "").Contains(keyword))
                .ToListAsync();

        public List<GymClass> GetEnrolledClasses(int studentId) =>
            _context.ClassEnrollments
                .Include(e => e.GymClass)
                    .ThenInclude(c => c.Category)
                .Where(e => e.StudentId == studentId)
                .Select(e => e.GymClass)
                .ToList();

        public async Task<List<GymClass>> GetEnrolledClassesAsync(int studentId) =>
            await _context.ClassEnrollments
                .Include(e => e.GymClass)
                    .ThenInclude(c => c.Category)
                .Where(e => e.StudentId == studentId)
                .Select(e => e.GymClass)
                .ToListAsync();

        public List<Coach> GetCoaches(int studentId) =>
            _context.ClassEnrollments
                .Include(e => e.GymClass)
                    .ThenInclude(c => c.Coach)
                        .ThenInclude(co => co.Person)
                .Where(e => e.StudentId == studentId)
                .Select(e => e.GymClass.Coach!)
                .Distinct()
                .ToList();

        public async Task<List<Coach>> GetCoachesAsync(int studentId) =>
            await _context.ClassEnrollments
                .Include(e => e.GymClass)
                    .ThenInclude(c => c.Coach)
                        .ThenInclude(co => co.Person)
                .Where(e => e.StudentId == studentId)
                .Select(e => e.GymClass.Coach!)
                .Distinct()
                .ToListAsync();

        public int GetTotalEnrollments(int studentId) =>
            _context.ClassEnrollments.Count(e => e.StudentId == studentId);

        public async Task<int> GetTotalEnrollmentsAsync(int studentId) =>
            await _context.ClassEnrollments.CountAsync(e => e.StudentId == studentId);
    }
}
