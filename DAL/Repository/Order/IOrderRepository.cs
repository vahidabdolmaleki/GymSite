using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        // همه سفارش های یک کاربر
        List<Order> GetOrderByPerson(int personId);
        Task<List<Order>> GetOrderByPersonAsync(int personId);
        //شفارش های پرداخت نشده
        List<Order> GetPendingOrders();
        Task<List<Order>> GetPendingOrdersAsync();
        // گرفتن سفارش به همراه آیتم ها
        Order? GetOrderWithItems(int orderId);
        Task<Order?> GetOrderWithItemsAsync(int orderId);
        //محاسبه مجموع مبلغ سفارش ها
        decimal GetTotalAmount(int orderId);
        Task<decimal> GetTotalAmountAsync(int orderId);        
    }
}
