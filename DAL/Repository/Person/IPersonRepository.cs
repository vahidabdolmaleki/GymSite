using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person? FindByUsername(string username);
        Task<Person?> FindByUsernameAsync(string username);

        Person? FindByNationalCode(string nationalCode);
        Task<Person?> FindByNationalCodeAsync(string nationalCode);

        Task<Person?> FindByIdAsync(int Id);
        Task<Person?> FindByUsernameOrPhoneAsync(string usernameOrPhone);
        IQueryable<Person> GetAllWithDevices();
    }

}
