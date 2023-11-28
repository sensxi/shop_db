using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice.Data;
using Practice.Models;

namespace Practice.Services
{
    public class DataSeedService : IDataSeedService
    {
        private readonly ApplicationDbContext _context;

        public DataSeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> SeedDatabaseAsync()
        {
            if (_context.Shops.Any())
            {
                return "Database already seeded.";
            }

            var shops = new List<Shop>
            {
                new Shop { Name = "shop_1", Description = "Shop number 1" },
                new Shop { Name = "shop_2", Description = "Shop number 2" },
                
                // Add more entities as needed
            };

            var departments = new List<Department>
            {
                new Department { Name = "Dep_1", ShopId = shops[0].Id },
                new Department { Name = "Dep_2", ShopId = shops[1].Id },
                new Department { Name = "Dep_3", ShopId = shops[1].Id },
                // Add more groups as needed
            };

            var products = new List<Product>
            {
                new Product { Name = "cigarettes", Cost = 10, Amount = 15, DepartmentId = departments[0].Id },
                new Product { Name = "vine", Cost = 15, Amount = 25, DepartmentId = departments[0].Id },
                new Product { Name = "vodka", Cost = 20, Amount = 35, DepartmentId = departments[1].Id },
                new Product { Name = "condoms", Cost = 50, Amount = 45, DepartmentId = departments[0].Id },
            };

            await _context.Shops.AddRangeAsync(shops);
            await _context.SaveChangesAsync();

            foreach (var shop in shops)
            {
                departments.Add(new Department { Name = $"Department {shop.Name}", ShopId = shop.Id });
            }

            await _context.Departments.AddRangeAsync(departments);
            await _context.SaveChangesAsync();

            foreach (var department in departments)
            {
                products.Add(new Product { Name = $"Product {department.Name}", DepartmentId = department.Id });
            }

            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();

            return "Database seeded successfully.";
        }
    }
}
