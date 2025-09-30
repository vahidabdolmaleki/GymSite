using DAL.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly GymDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(GymDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        // --- CRUD ---
        public void Save(TEntity entity) => _dbSet.Add(entity);
        public void Update(TEntity entity) => _dbSet.Update(entity);

        public void Remove(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public TEntity? Find(int id) => _dbSet.Find(id);
        public List<TEntity> GetAll() => _dbSet.ToList();
        public IQueryable<TEntity> GetAllQueryable() => _dbSet.AsQueryable();

        // --- Async ---
        public async Task SaveAsync(TEntity entity) => await _dbSet.AddAsync(entity);
        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public async Task<TEntity?> FindAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<List<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
    }

}
