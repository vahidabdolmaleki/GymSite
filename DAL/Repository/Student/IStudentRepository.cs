using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        // 🎓 دریافت همه شاگردها همراه با اطلاعات شخصی و کلاس‌های ثبت‌نامی
        List<Student> GetAllWithDetails();
        Task<List<Student>> GetAllWithDetailsAsync();

        // 🔍 جستجو شاگرد بر اساس نام، کدملی یا شماره تلفن
        List<Student> Search(string keyword);
        Task<List<Student>> SearchAsync(string keyword);

        // 🏋️‍♂️ دریافت کلاس‌های ثبت‌نامی یک شاگرد خاص
        List<GymClass> GetEnrolledClasses(int studentId);
        Task<List<GymClass>> GetEnrolledClassesAsync(int studentId);

        // 👨‍🏫 دریافت مربی‌های شاگرد (از روی کلاس‌هایی که شرکت کرده)
        List<Coach> GetCoaches(int studentId);
        Task<List<Coach>> GetCoachesAsync(int studentId);

        // 📈 دریافت تعداد کل کلاس‌هایی که شرکت کرده
        int GetTotalEnrollments(int studentId);
        Task<int> GetTotalEnrollmentsAsync(int studentId);

        // 🧑‍🏫 جستجوی تمام دانش آموزان براساس کد مربی
        Task<List<Student>> GetByCoachIdAsync(int CoachId);
        Task<Student?> GetFullByIdAsync(int studentId);
    }
}
