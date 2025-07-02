using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Domain.Entities;

namespace Practice.Application.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product?> GetByIdAsync(int id);
        public Task<List<Product>> GetByBrandIdAsync(int brandId);
        public Task<List<Product>> GetByCategoryIdAsync(int categoryId);
        public Task<Product> AddAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(int id);
    }
}
