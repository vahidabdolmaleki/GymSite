using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.AddressRepository
{
    public interface IAddressRepository : IDisposable
    {
        void Save(Address address);
        void Update(Address address);
        void Remove(int Id);
        Address Find(int Id);
        List<Address> GetAll();
        IQueryable<Address> GetAllQueryable();
    }
}
