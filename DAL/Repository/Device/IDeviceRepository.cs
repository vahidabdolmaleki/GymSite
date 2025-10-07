using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IDeviceRepository:IGenericRepository<Device>
    {
        //نمایش دستگاه های یک شخص خاص
        List<Device> GetByPerson(int personId);
        Task<List<Device>> GetByPersonAsync(int personId);
        // نمایش دستگاه های فعال
        List<Device> GetActiveDevices();
        Task<List<Device>> GetActiveDevicesAsync();
        //غیرفعال کردن دستگاه
        void DeactivateDevice(int id);
        Task DeactivateDeviceAsync(int id);
    }
}
