using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IGymClassRepository:IGenericRepository<GymClass>
    {
        // 📅 دریافت همه کلاس‌ها با مربی و دسته‌بندی
        List<GymClass> GetAllWithDetails();
        Task<List<GymClass>> GetAllWithDetailsAsync();

        // 👨‍🏫 کلاس‌های مربوط به یک مربی خاص
        List<GymClass> GetByCoach(int coachId);
        Task<List<GymClass>> GetByCoachAsync(int coachId);

        // 🧍‍♂️ کلاس‌هایی که یک شاگرد در آن ثبت‌نام کرده
        List<GymClass> GetByStudent(int studentId);
        Task<List<GymClass>> GetByStudentAsync(int studentId);

        // 🕒 کلاس‌های فعال (یعنی هنوز تمام نشده‌اند)
        List<GymClass> GetActiveClasses();
        Task<List<GymClass>> GetActiveClassesAsync();

        // 🔍 جستجو بر اساس عنوان یا توضیحات
        List<GymClass> Search(string keyword);
        Task<List<GymClass>> SearchAsync(string keyword);
    }
}
