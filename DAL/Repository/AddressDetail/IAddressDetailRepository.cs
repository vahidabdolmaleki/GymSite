using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IAddressDetailRepository : IGenericRepository<AddressDetail>
    {
        // جزئیات آدرس بر اساس شهر
        List<AddressDetail> GetByCity(int cityId);
        Task<List<AddressDetail>> GetByCityAsync(int cityId);

        // جزئیات آدرس بر اساس استان
        List<AddressDetail> GetByUnit(int unitId);
        Task<List<AddressDetail>> GetByUnitAsync(int unitId);

        // جستجو بر اساس کد پستی
        AddressDetail? FindByPostalCode(string postalCode);
        Task<AddressDetail?> FindByPostalCodeAsync(string postalCode);
    }
}
