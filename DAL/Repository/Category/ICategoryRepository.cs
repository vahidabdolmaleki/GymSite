using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        // دریافت همه دسته‌ها با کلاس‌های مرتبط
        List<Category> GetAllWithClasses();
        Task<List<Category>> GetAllWithClassesAsync();

        // پیدا کردن دسته بر اساس نام (برای جستجو)
        Category? GetByTitle(string title);
        Task<Category?> GetByTitleAsync(string title);

        // بررسی تکراری بودن عنوان دسته
        bool Exists(string title);
        Task<bool> ExistsAsync(string title);
    }
}
