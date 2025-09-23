using DAL.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.AddressDetailRepository
{
    public class AddressDetailRepository : IAddressDetailRepository
    {
        private bool disposed = false;
        private readonly GymDbContext _gymDbContext;

        public AddressDetailRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _gymDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public AddressDetail Find(int Id)
        {
            return _gymDbContext.AddressDetails.Find(Id);
        }

        public List<AddressDetail> GetAll()
        {
            return _gymDbContext.AddressDetails.ToList();
        }

        public IQueryable<AddressDetail> GetAllQueryable()
        {
            return _gymDbContext.AddressDetails;
        }

        public void Remove(int Id)
        {
            AddressDetail addressDetail = Find(Id);
            _gymDbContext.AddressDetails.Remove(addressDetail);
        }

        public void Save(AddressDetail address)
        {
            _gymDbContext.AddressDetails.Add(address);
        }

        public void Update(AddressDetail address)
        {
            _gymDbContext.AddressDetails.Update(address);
        }
    }
}
