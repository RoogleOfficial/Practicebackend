using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Domain.Entities;

namespace Practice.Application.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(int id);

        public Task<List<Category>> GetCategoriesByListOfIds(List<int> ids);
        public Task<Category> AddAsync(Category category);
        public Task UpdateAsync(Category category);
        public Task DeleteAsync(int id);

        public Task<List<Category>> GetByProductIdAsync(int productId);
        public Task<Category> GetProductsByCategory(string CategoryName);
    }
}
