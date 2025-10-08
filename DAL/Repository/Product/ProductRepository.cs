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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(GymDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> SearchByName(string keyword)
        {
            return _dbSet
                .Where(p => p.Title.Contains(keyword))
                .ToList();
        }

        public IEnumerable<Product> GetLowStockProducts(int threshold)
        {
            return _dbSet
                .Where(p => p.Stock < threshold)
            .ToList();
        }

        public void UpdateStock(int productId, int quantity)
        {
            var product = _dbSet.FirstOrDefault(p => p.Id == productId);
            if (product == null) return;

            product.Stock -= quantity;
            _context.SaveChanges();
        }
    }
}
