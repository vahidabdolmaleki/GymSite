using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(GymDbContext gymDbContext):base(gymDbContext){}

        public List<Order> GetOrderByPerson(int personId)
        {
            return _dbSet.Where(o => o.PersonId == personId).ToList();
        }

        public async Task<List<Order>> GetOrderByPersonAsync(int personId)
        {
            return await _dbSet.Where(o => o.PersonId == personId).ToListAsync();
        }

        public Order? GetOrderWithItems(int orderId)
        {
            return _dbSet.Include(o => o.Items).FirstOrDefault(o => o.Id == orderId);
        }

        public async Task<Order?> GetOrderWithItemsAsync(int orderId)
        {
            return await _dbSet.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public List<Order> GetPendingOrders()
        {
            return _dbSet.Where(o => o.Status == "Pending").ToList();
        }

        public async Task<List<Order>> GetPendingOrdersAsync()
        {
            return await _dbSet.Where(o => o.Status == "Pending").ToListAsync();
        }

        public decimal GetTotalAmount(int orderId)
        {
            var order = _dbSet.Include(o => o.Items).FirstOrDefault(o => o.Id == orderId);
            return order?.Items.Sum(i => i.Quantity * i.UnitPrice) ?? 0;
        }

        public async Task<decimal> GetTotalAmountAsync(int orderId)
        {
            var order = await _dbSet.Include(o => o.Items).FirstOrDefaultAsync(o=> o.Id == orderId);
            return order?.Items.Sum(i => i.Quantity * i.UnitPrice) ?? 0;
        }
    }
}
