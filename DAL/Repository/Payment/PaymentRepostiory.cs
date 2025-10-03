using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PaymentRepostiory : GenericRepository<Payment>, IpaymentRepository
    {
        public PaymentRepostiory(GymDbContext gymDbContext) : base(gymDbContext){}

        public List<Payment> GetPaymentsByPerson(int personId) => _dbSet.Where(p=> p.Id == personId).ToList();
        public async Task<List<Payment>> GetPaymentByPersonAsync(int personId) => await _dbSet.Where(p=> p.Id == personId).ToListAsync();
        public List<Payment> GetSuccessfulPayments() => _dbSet.Where(p => p.Status =="Success").ToList();
        public async Task<List<Payment>> GetSuccessfulPaymentAsync() => await _dbSet.Where(p => p.Status =="Success").ToListAsync();
        public List<Payment> GetFailPayments() => _dbSet.Where(p=> p.Status =="Failed").ToList();
        public async Task<List<Payment>> GetFailPaymentsAsync() => await _dbSet.Where(p=> p.Status =="Failed").ToListAsync();
        public List<Payment> GetPaymentsByOrder(int orderId)=> _dbSet.Where(p=> p.OrderId == orderId).ToList();
        public async Task<List<Payment>> GetPaymentsByOrderAsync(int orderId) => await _dbSet.Where(p=> p.OrderId == orderId).ToListAsync();
        public Payment? GetLastPayment(int personId) => _dbSet.Where(p => p.PersonId == personId).OrderByDescending(p => p.PaidAt).FirstOrDefault();
        public async Task<Payment?> GetLastPaymentAsync(int personId) => await _dbSet.Where(p => p.PersonId == personId).OrderByDescending(p=> p.PaidAt).FirstOrDefaultAsync();
    }
}
