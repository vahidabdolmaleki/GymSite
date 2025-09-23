using DAL.Context;
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

        public UnitOfWork()
        {

        }
        public UnitOfWork(GymDbContext gymDbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _gymDbContext = gymDbContext;
        }
        public void Commit()
        {
            _gymDbContext.SaveChanges();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
