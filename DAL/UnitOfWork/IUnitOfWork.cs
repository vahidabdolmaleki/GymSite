using DAL.Repository.AddressDetailRepository;
using DAL.Repository.AddressRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository AddressRepository { get; }
        IAddressDetailRepository AddressDetailRepository { get; }
        void Commit();
    }
}
