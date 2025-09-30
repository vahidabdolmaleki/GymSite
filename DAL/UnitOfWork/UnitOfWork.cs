using DAL.Context;
using DAL.Repository;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly GymDbContext _gymDbContext;

        public UnitOfWork(GymDbContext gymDbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _gymDbContext = gymDbContext;
        }

        // --- Repositoryها ---
        public IPersonRepository PersonRepository => new PersonRepository(_gymDbContext);
        public IGenericRepository<AddressDetail> AddressDetailRepository => new GenericRepository<AddressDetail>(_gymDbContext);
        public IGenericRepository<Product> ProductRepository => new GenericRepository<Product>(_gymDbContext);



        public void Commit()
        {
            _gymDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _gymDbContext.Dispose();
        }
    }
}
