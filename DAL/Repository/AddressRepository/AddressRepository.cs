using DAL.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.AddressRepository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly GymDbContext _gymDbcontext;

        public AddressRepository(GymDbContext gymDbContext)
        {
                _gymDbcontext = gymDbContext;
        }
        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _gymDbcontext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Address Find(int Id)
        {
            return _gymDbcontext.Addresses.Find(Id);
        }

        public List<Address> GetAll()
        {
            return _gymDbcontext.Addresses.ToList();
        }

        public void Save(Address address)
        {
            _gymDbcontext.Addresses.Add(address);
        }

        public void Update(Address address)
        {
            _gymDbcontext.Addresses.Update(address);
        }

        public IQueryable<Address> GetAllQueryable()
        {
            return _gymDbcontext.Addresses;
        }
        public void Remove(int Id) 
        {
            Address address = Find(Id);
            _gymDbcontext.Addresses.Remove(address);
        }

        
    }
}
