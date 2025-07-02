using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice.Application.Interfaces;
using Practice.Domain.Entities;
using Practice.Infrastructure.Configurations.Context;

namespace Practice.Infrastructure.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Include(c => c.products)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetByProductIdAsync(int productId)
        {
            return await _context.Categories
                .Where(c => c.products.Any(p => p.Id == productId))
                .Include(c => c.products)
                .ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesByListOfIds(List<int> ids)
        {
            return await _context.Categories
                         .Where(c => ids.Contains(c.Id))
                         .ToListAsync();
        }

        public async Task<Category?> GetProductsByCategory(string CategoryName)
        {
            return await _context.Categories
            .Include(c => c.products)
            .FirstOrDefaultAsync(c => c.Name.ToLower() == CategoryName.ToLower());
        }
                
              

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
        

    }
}
