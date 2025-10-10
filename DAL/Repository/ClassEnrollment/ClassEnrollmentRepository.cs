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
    public class ClassEnrollmentRepository : GenericRepository<ClassEnrollment> , IClassEnrollmentRepository
    {
        private readonly GymDbContext _gymDbContext;

        public ClassEnrollmentRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<ClassEnrollment> GetByClassId(int classId) =>
            _gymDbContext.ClassEnrollments
                .Include(e => e.Student)
                .Include(e => e.GymClass)
                .Where(e => e.GymClassId == classId)
                .OrderByDescending(e => e.EnrolledAt)
                .ToList();

        public async Task<List<ClassEnrollment>> GetByClassIdAsync(int classId) =>
            await _gymDbContext.ClassEnrollments
                .Include(e => e.Student)
                .Include(e => e.GymClass)
                .Where(e => e.GymClassId == classId)
                .OrderByDescending(e => e.EnrolledAt)
                .ToListAsync();

        public List<ClassEnrollment> GetByStudentId(int studentId) =>
            _gymDbContext.ClassEnrollments
                .Include(e => e.GymClass).ThenInclude(c => c.Coach)
                .Where(e => e.StudentId == studentId)
                .OrderByDescending(e => e.EnrolledAt)
                .ToList();

        public async Task<List<ClassEnrollment>> GetByStudentIdAsync(int studentId) =>
            await _gymDbContext.ClassEnrollments
                .Include(e => e.GymClass).ThenInclude(c => c.Coach)
                .Where(e => e.StudentId == studentId)
                .OrderByDescending(e => e.EnrolledAt)
                .ToListAsync();

        public bool IsEnrolled(int studentId, int classId) =>
            _gymDbContext.ClassEnrollments.Any(e => e.StudentId == studentId && e.GymClassId == classId);

        public async Task<bool> IsEnrolledAsync(int studentId, int classId) =>
            await _gymDbContext.ClassEnrollments.AnyAsync(e => e.StudentId == studentId && e.GymClassId == classId);

        public List<ClassEnrollment> GetPaidEnrollments(int studentId) =>
            _gymDbContext.ClassEnrollments
                .Include(e => e.GymClass)
                .Where(e => e.StudentId == studentId && e.IsPaid)
                .OrderByDescending(e => e.EnrolledAt)
                .ToList();

        public async Task<List<ClassEnrollment>> GetPaidEnrollmentsAsync(int studentId) =>
            await _gymDbContext.ClassEnrollments
                .Include(e => e.GymClass)
                .Where(e => e.StudentId == studentId && e.IsPaid)
                .OrderByDescending(e => e.EnrolledAt)
                .ToListAsync();
    }
}
