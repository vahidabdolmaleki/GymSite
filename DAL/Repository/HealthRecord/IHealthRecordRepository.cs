using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IHealthRecordRepository: IGenericRepository<HealthRecord>
    {
        // آخرین رکورد سلامت یک شخص
        HealthRecord? GetLatestByPersonId(int personId);
        Task<HealthRecord?> GetLatestByPersonIdAsync(int personId);

        // لیست همه رکوردهای سلامت کاربر
        List<HealthRecord> GetByPersonId(int personId);
        Task<List<HealthRecord>> GetByPersonIdAsync(int personId);

        // میانگین BMI در بازه زمانی
        double GetAverageBmi(int personId, DateTime startDate, DateTime endDate);
        Task<double> GetAverageBmiAsync(int personId, DateTime startDate, DateTime endDate);
    }
}
