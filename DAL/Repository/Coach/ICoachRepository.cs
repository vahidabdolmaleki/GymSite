using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface ICoachRepository : IGenericRepository<Coach>
    {
        // 👨‍🏫 دریافت تمام مربیان همراه با اطلاعات شخصی و کلاس‌ها
        List<Coach> GetAllWithDetails();
        Task<List<Coach>> GetAllWithDetailsAsync();

        // 🔍 جستجو مربی بر اساس نام یا تخصص
        List<Coach> Search(string keyword);
        Task<List<Coach>> SearchAsync(string keyword);

        // 🏋️ دریافت کلاس‌های یک مربی خاص
        List<GymClass> GetCoachClasses(int coachId);
        Task<List<GymClass>> GetCoachClassesAsync(int coachId);

        // 📊 تعداد شاگردهای زیر نظر مربی
        int GetStudentCount(int coachId);
        Task<int> GetStudentCountAsync(int coachId);
    }
}
