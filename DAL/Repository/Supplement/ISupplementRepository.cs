using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.SupplementRepository
{
    public interface ISupplementRepository : IGenericRepository<Supplement>
    {

        // 🔹 مکمل‌هایی که تاریخ انقضای آن‌ها گذشته است
        List<Supplement> GetExpiredSupplements();
        Task<List<Supplement>> GetExpiredSupplementsAsync();

        // 🔹 مکمل‌های در آستانه انقضا (مثلاً کمتر از X روز مانده)
        List<Supplement> GetExpiringSoon(int days);
        Task<List<Supplement>> GetExpiringSoonAsync(int days);

        // 🔹 مکمل‌هایی که موجودی کمی دارند
        List<Supplement> GetLowStock(int threshold);
        Task<List<Supplement>> GetLowStockAsync(int threshold);

        // 🔹 بروزرسانی موجودی پس از خرید یا ورود کالا
        void UpdateStock(int id, int quantityChange);
        Task UpdateStockAsync(int id, int quantityChange);
    }
}
