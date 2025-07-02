using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Domain.Entities;

namespace Practice.Application.Interfaces
{
    public interface IBrandRepository
    {
        public Task<List<Brand>> GetAllAsync();
        public Task<Brand?> GetByIdAsync(int id);
        public Task<Brand> AddAsync(Brand brand);
        public Task UpdateAsync(Brand brand);
        public Task DeleteAsync(int id);

        public Task<Brand?> GetBrandWithProductsAsync(int id);
    }
}
