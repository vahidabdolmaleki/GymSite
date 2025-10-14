using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        // آدرس‌های یک شخص خاص
        List<Address> GetByPerson(int personId);
        Task<List<Address>> GetByPersonAsync(int personId);

        // آدرس اصلی (Primary) کاربر
        Address? GetPrimaryAddress(int personId);
        Task<Address?> GetPrimaryAddressAsync(int personId);

        // آدرس‌ها بر اساس استان یا شهر
        List<Address> GetByCity(int cityId);
        Task<List<Address>> GetByCityAsync(int cityId);
    }
}
