
using DAL.Repository.GenericRepository;
using DAL.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }

        
        
        //---- GenericRepository
        IGenericRepository<AddressDetail> AddressDetailRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        void Commit();
    }
}
