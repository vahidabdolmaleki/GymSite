using DAL.Repository.GenericRepository;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IMembershipTypeRepository : IGenericRepository<Membership>
    {
        Membership? GetByTitle(string title);
        Task<Membership?> GetByTitleAsync(string title);

        List<Membership> GetAvailableMemberships();
        Task<List<Membership>> GetAvailableMembershipsAsync();
    }
}
