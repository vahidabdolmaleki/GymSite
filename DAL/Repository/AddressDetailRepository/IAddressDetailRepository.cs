using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.AddressDetailRepository
{
    public interface IAddressDetailRepository:IDisposable
    {
        void Save(AddressDetail address);
        void Update(AddressDetail address);
        void Remove(int Id);
        AddressDetail Find(int Id);
        List<AddressDetail> GetAll();
        IQueryable<AddressDetail> GetAllQueryable();
    }
}
