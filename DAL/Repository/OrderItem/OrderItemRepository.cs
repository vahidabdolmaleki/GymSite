using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly GymDbContext _context;

        public OrderItemRepository(GymDbContext context) : base(context)
        {
            _context = context;
        }

        public List<OrderItem> GetByOrderId(int orderId)
        {
            return _context.OrderItems
                .Include(oi => oi.Product)
                .Where(oi => oi.OrderId == orderId)
                .ToList();
        }

        public async Task<List<OrderItem>> GetByOrderIdAsync(int orderId)
        {
            return await _context.OrderItems
                .Include(oi => oi.Product)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }

        public decimal GetTotalAmountByOrderId(int orderId)
        {
            return _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .Sum(oi => oi.Quantity * oi.UnitPrice);
        }

        public async Task<decimal> GetTotalAmountByOrderIdAsync(int orderId)
        {
            return await _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .SumAsync(oi => oi.Quantity * oi.UnitPrice);
        }
    }
}
