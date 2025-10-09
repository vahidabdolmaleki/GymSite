using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IpaymentRepository:IGenericRepository<Payment> 
    {
        // همه پرداخت‌های یک کاربر
        List<Payment> GetPaymentsByPerson(int personId);
        Task<List<Payment>> GetPaymentsByPersonAsync(int personId);

        // پرداخت‌های موفق
        List<Payment> GetSuccessfulPayments();
        Task<List<Payment>> GetSuccessfulPaymentsAsync();

        // پرداخت‌های ناموفق
        List<Payment> GetFailedPayments();
        Task<List<Payment>> GetFailedPaymentsAsync();

        // پرداخت‌های مرتبط با یک سفارش
        List<Payment> GetPaymentsByOrder(int orderId);
        Task<List<Payment>> GetPaymentsByOrderAsync(int orderId);

        // آخرین پرداخت یک کاربر
        Payment? GetLastPayment(int personId);
        Task<Payment?> GetLastPaymentAsync(int personId);
    }
}
