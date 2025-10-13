using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IPersonRoleRepostiory : IGenericRepository<PersonRole>
    {
        // تمام نقش‌های یک شخص
        List<PersonRole> GetRolesByPersonId(int personId);
        Task<List<PersonRole>> GetRolesByPersonIdAsync(int personId);

        // تمام افراد دارای یک نقش خاص
        List<PersonRole> GetPersonsByRoleId(int roleId);
        Task<List<PersonRole>> GetPersonsByRoleIdAsync(int roleId);

        // بررسی اینکه شخص خاصی نقش خاصی دارد یا نه
        bool HasRole(int personId, int roleId);
        Task<bool> HasRoleAsync(int personId, int roleId);
    }
}
