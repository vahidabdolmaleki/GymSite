using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        private readonly GymDbContext _gymDbContext;

        public DeviceRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<Device> GetByPerson(int personId)
        {
            return _dbSet.Where(d => d.PersonId == personId).ToList();
        }

        public async Task<List<Device>> GetByPersonAsync(int personId)
        {
            return await _dbSet.Where(d => d.PersonId == personId).ToListAsync();
        }

        public List<Device> GetActiveDevices()
        {
            return _dbSet.Where(d => d.IsActive).ToList();
        }

        public async Task<List<Device>> GetActiveDevicesAsync()
        {
            return await _dbSet.Where(d => d.IsActive).ToListAsync();
        }

        public void DeactivateDevice(int id)
        {
            var device = _dbSet.Find(id);
            if (device != null)
            {
                device.IsActive = false;
                _dbSet.Update(device);
            }
        }

        public async Task DeactivateDeviceAsync(int id)
        {
            var device = await _dbSet.FindAsync(id);
            if (device != null)
            {
                device.IsActive = false;
                _dbSet.Update(device);
            }
        }
    }
}
