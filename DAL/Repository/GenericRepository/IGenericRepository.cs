using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        // --- CRUD ---
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
        TEntity? Find(int id);
        List<TEntity> GetAll();
        IQueryable<TEntity> GetAllQueryable();

        // --- Async ---
        Task SaveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(int id);
        Task<TEntity?> FindAsync(int id);
        Task<List<TEntity>> GetAllAsync();
    }

}
