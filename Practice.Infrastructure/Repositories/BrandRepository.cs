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
    public class BrandRepository:IBrandRepository
    {
        private readonly AppDbContext _context;

        public BrandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Brand> AddAsync(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Brands
                .Include(b => b.Products)
                .ToListAsync();
        }

        public async Task<Brand?> GetBrandWithProductsAsync(int id)
        {
            return await _context.Brands
               .Include(b => b.Products)
               .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            return await _context.Brands
               .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Brand brand)
        {
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
        }
    }
}
