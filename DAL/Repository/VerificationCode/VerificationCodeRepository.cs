using DAL.Context;
using DAL.Repositories.Interfaces;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class VerificationCodeRepository : GenericRepository<VerificationCode>, IVerificationCodeRepository
    {
        private readonly GymDbContext _context;

        public VerificationCodeRepository(GymDbContext context) : base(context)
        {
            _context = context;
        }
        /// <summary>
        /// دریافت کد فعال برای کاربر مشخص
        /// فقط کدهایی را برمی‌گرداند که منقضی نشده و استفاده‌نشده باشند.
        /// </summary>
        public async Task<VerificationCode?> GetActiveCodeAsync(int personId, string code)
        {
            return await _context.VerificationCodes
                .Where(v => v.PersonId == personId && v.Code == code && !v.IsUsed && v.ExpireAt > DateTime.UtcNow)
                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// همه کدهای فعال و منقضی‌نشده برای شخص (برای پاک‌سازی یا غیرفعال‌سازی بقیه)
        /// </summary>
        public async Task<IEnumerable<VerificationCode>> GetAllActiveByPersonAsync(int personId)
        {
            return await _context.VerificationCodes
                .Where(v => v.PersonId == personId && !v.IsUsed && v.ExpireAt > DateTime.UtcNow)
                .ToListAsync();
        }
    }
}
