using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        // دریافت آیتم‌های یک سفارش
        List<OrderItem> GetByOrderId(int orderId);
        Task<List<OrderItem>> GetByOrderIdAsync(int orderId);

        // محاسبه مجموع مبلغ یک سفارش
        decimal GetTotalAmountByOrderId(int orderId);
        Task<decimal> GetTotalAmountByOrderIdAsync(int orderId);
    }
}
