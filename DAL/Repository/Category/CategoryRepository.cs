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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly GymDbContext _gymDbContext;

        public CategoryRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<Category> GetAllWithClasses() =>
            _gymDbContext.Categories
                    .Include(c => c.Classes)
                    .OrderBy(c => c.Title)
                    .ToList();

        public async Task<List<Category>> GetAllWithClassesAsync() =>
            await _gymDbContext.Categories
                    .Include(c => c.Classes)
                    .OrderBy(c => c.Title)
                    .ToListAsync();

        public Category? GetByTitle(string title) =>
            _gymDbContext.Categories
                    .Include(c => c.Classes)
                    .FirstOrDefault(c => c.Title.ToLower() == title.ToLower());

        public async Task<Category?> GetByTitleAsync(string title) =>
            await _gymDbContext.Categories
                    .Include(c => c.Classes)
                    .FirstOrDefaultAsync(c => c.Title.ToLower() == title.ToLower());

        public bool Exists(string title) =>
            _gymDbContext.Categories.Any(c => c.Title.ToLower() == title.ToLower());

        public async Task<bool> ExistsAsync(string title) =>
            await _gymDbContext.Categories.AnyAsync(c => c.Title.ToLower() == title.ToLower());
    }
}
