using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.LogRepository
{
    public class LogRepository : GenericRepository<Log>, ILogRepository
    {
        public LogRepository(GymDbContext context) : base(context)
        {
        }

        // 🔹 لاگ‌های مربوط به یک کاربر خاص
        public List<Log> GetLogsByUser(int userId)
        {
            return _dbSet.Where(l => l.UserId == userId)
                         .OrderByDescending(l => l.CreatedAt)
                         .ToList();
        }

        public async Task<List<Log>> GetLogsByUserAsync(int userId)
        {
            return await _dbSet.Where(l => l.UserId == userId)
                               .OrderByDescending(l => l.CreatedAt)
                               .ToListAsync();
        }

        // 🔹 لاگ‌های بین دو تاریخ
        public List<Log> GetLogsByDateRange(DateTime start, DateTime end)
        {
            return _dbSet.Where(l => l.CreatedAt >= start && l.CreatedAt <= end)
                         .OrderByDescending(l => l.CreatedAt)
                         .ToList();
        }

        public async Task<List<Log>> GetLogsByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _dbSet.Where(l => l.CreatedAt >= start && l.CreatedAt <= end)
                               .OrderByDescending(l => l.CreatedAt)
                               .ToListAsync();
        }

        // 🔹 لاگ‌های بر اساس نوع اکشن (مثلاً Login, Logout, Error)
        public List<Log> GetLogsByAction(string action)
        {
            return _dbSet.Where(l => l.Action == action)
                         .OrderByDescending(l => l.CreatedAt)
                         .ToList();
        }

        public async Task<List<Log>> GetLogsByActionAsync(string action)
        {
            return await _dbSet.Where(l => l.Action == action)
                               .OrderByDescending(l => l.CreatedAt)
                               .ToListAsync();
        }

        // 🔹 حذف لاگ‌های قدیمی‌تر از X روز (برای نگهداری حجم دیتابیس)
        public void RemoveOldLogs(int days)
        {
            var cutoff = DateTime.UtcNow.AddDays(-days);
            var oldLogs = _dbSet.Where(l => l.CreatedAt < cutoff).ToList();
            _dbSet.RemoveRange(oldLogs);
        }

        public async Task RemoveOldLogsAsync(int days)
        {
            var cutoff = DateTime.UtcNow.AddDays(-days);
            var oldLogs = await _dbSet.Where(l => l.CreatedAt < cutoff).ToListAsync();
            _dbSet.RemoveRange(oldLogs);
        }
    }
}
