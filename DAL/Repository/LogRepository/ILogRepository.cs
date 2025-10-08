using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.LogRepository
{
    public interface ILogRepository:IGenericRepository<Log>
    {
        // 🔹 دریافت لاگ‌های کاربر خاص
        List<Log> GetLogsByUser(int userId);
        Task<List<Log>> GetLogsByUserAsync(int userId);

        // 🔹 دریافت لاگ‌های بین دو تاریخ
        List<Log> GetLogsByDateRange(DateTime start, DateTime end);
        Task<List<Log>> GetLogsByDateRangeAsync(DateTime start, DateTime end);

        // 🔹 دریافت لاگ‌های با نوع خاص (Action فیلتر)
        List<Log> GetLogsByAction(string action);
        Task<List<Log>> GetLogsByActionAsync(string action);

        // 🔹 حذف لاگ‌های قدیمی‌تر از X روز
        void RemoveOldLogs(int days);
        Task RemoveOldLogsAsync(int days);
    }
}
