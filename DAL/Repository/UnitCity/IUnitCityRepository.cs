using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUnitCityRepository : IGenericRepository<UnitCity>
    {
        // دریافت لیست استان‌ها
        List<UnitCity> GetAllProvinces();
        Task<List<UnitCity>> GetAllProvincesAsync();

        // دریافت شهرهای مربوط به یک استان خاص
        List<UnitCity> GetCitiesByProvince(int provinceId);
        Task<List<UnitCity>> GetCitiesByProvinceAsync(int provinceId);

        // دریافت نام استان یا شهر بر اساس Id
        string? GetNameById(int id);
        Task<string?> GetNameByIdAsync(int id);
    }
}
