using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IProductRepository : IGenericRepository<Product> 
    {
        // جستجوی محصول بر اساس نام (برای سرچ یا فیلتر)
        IEnumerable<Product> SearchByName(string keyword);

        // محصولات با موجودی کم (برای هشدار انبار)
        IEnumerable<Product> GetLowStockProducts(int threshold);

        // به‌روزرسانی موجودی محصول بعد از سفارش
        void UpdateStock(int productId, int quantity);
    }
}
