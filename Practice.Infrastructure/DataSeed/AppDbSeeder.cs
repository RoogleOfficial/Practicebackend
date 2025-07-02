using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using Practice.Application.DTOs;
using Practice.Domain.Entities;
using Practice.Infrastructure.Configurations.Context;

namespace Practice.Infrastructure.DataSeed
{
    public class AppDbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            Console.WriteLine("SeedAsync Method Invoked Seeding Data...");
            if (!context.Categories.Any() && !context.Products.Any() && !context.Brands.Any())
            {
                Console.WriteLine("Inserting data...");
                var category = new Category
                {
                    Name = "Electronics",
                    Description = "All kinds of electronic items",
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                };

                var brand = new Brand
                {
                    Name = "Apple",
                    Description = "Premium tech brand",
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                };

                var product = new Product
                {
                    Name = "iPhone 15",
                    Type = "Smartphone",
                    ShortDescription = "Latest iPhone with A17 chip",
                    LongDescription = "Flagship device from Apple",
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                    Brand = brand,                     // associate with brand
                    Categories = new List<Category>    //associate with category
                    {
                        category
                    }
                };

                context.Products.Add(product);
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Data already exists. Skipping insert.");
            }
        }
    }
}
