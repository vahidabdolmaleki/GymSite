using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IClassEnrollmentRepository : IGenericRepository<ClassEnrollment>
    {
        // 📋 ثبت‌نام‌های یک کلاس خاص
        List<ClassEnrollment> GetByClassId(int classId);
        Task<List<ClassEnrollment>> GetByClassIdAsync(int classId);

        // 🧍‍♂️ ثبت‌نام‌های یک دانش‌آموز خاص
        List<ClassEnrollment> GetByStudentId(int studentId);
        Task<List<ClassEnrollment>> GetByStudentIdAsync(int studentId);

        // ✅ بررسی اینکه آیا یک شاگرد در کلاس خاصی ثبت‌نام کرده یا نه
        bool IsEnrolled(int studentId, int classId);
        Task<bool> IsEnrolledAsync(int studentId, int classId);

        // 💰 دریافت فقط ثبت‌نام‌های پرداخت‌شده
        List<ClassEnrollment> GetPaidEnrollments(int studentId);
        Task<List<ClassEnrollment>> GetPaidEnrollmentsAsync(int studentId);
    }
}
