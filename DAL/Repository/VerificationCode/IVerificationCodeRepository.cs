using DAL.Repository.GenericRepository;
using Entities;

namespace DAL.Repositories
{
    public interface IVerificationCodeRepository : IGenericRepository<VerificationCode>
    {
        Task<VerificationCode?> GetActiveCodeAsync(int personId, string code);
        Task<IEnumerable<VerificationCode>> GetAllActiveByPersonAsync(int personId);
    }
}
