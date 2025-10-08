using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.SupplementRepository
{
    internal class SupplementRepository : GenericRepository<Supplement>, ISupplementRepository
    {
        public SupplementRepository(GymDbContext context) : base(context)
        {
        }

        // 🔹 مکمل‌های منقضی شده
        public List<Supplement> GetExpiredSupplements()
        {
            return _dbSet.Where(s => s.ExpirationDate < DateTime.UtcNow).ToList();
        }

        public async Task<List<Supplement>> GetExpiredSupplementsAsync()
        {
            return await _dbSet.Where(s => s.ExpirationDate < DateTime.UtcNow).ToListAsync();
        }

        // 🔹 مکمل‌هایی که در آستانه انقضا هستند
        public List<Supplement> GetExpiringSoon(int days)
        {
            var limitDate = DateTime.UtcNow.AddDays(days);
            return _dbSet.Where(s => s.ExpirationDate >= DateTime.UtcNow && s.ExpirationDate <= limitDate).ToList();
        }

        public async Task<List<Supplement>> GetExpiringSoonAsync(int days)
        {
            var limitDate = DateTime.UtcNow.AddDays(days);
            return await _dbSet.Where(s => s.ExpirationDate >= DateTime.UtcNow && s.ExpirationDate <= limitDate).ToListAsync();
        }

        // 🔹 مکمل‌هایی که موجودی کمی دارند
        public List<Supplement> GetLowStock(int threshold)
        {
            return _dbSet.Where(s => s.Stock <= threshold).ToList();
        }

        public async Task<List<Supplement>> GetLowStockAsync(int threshold)
        {
            return await _dbSet.Where(s => s.Stock <= threshold).ToListAsync();
        }

        // 🔹 بروزرسانی موجودی انبار (مثبت یا منفی)
        public void UpdateStock(int id, int quantityChange)
        {
            var supplement = _dbSet.Find(id);
            if (supplement != null)
            {
                supplement.Stock += quantityChange;
                _dbSet.Update(supplement);
            }
        }

        public async Task UpdateStockAsync(int id, int quantityChange)
        {
            var supplement = await _dbSet.FindAsync(id);
            if (supplement != null)
            {
                supplement.Stock += quantityChange;
                _dbSet.Update(supplement);
            }
        }
    }
}
