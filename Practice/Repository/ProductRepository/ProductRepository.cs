using Microsoft.EntityFrameworkCore;
using Practice.Data;
using Practice.Models;
using Practice.Repository.ProductRepository;

namespace Practice.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(s => s.Department).ToListAsync();
        }

        public async Task<List<Product>> GetAllAsync(int departmentId)
        {
            return await _context.Products.Where(g => g.DepartmentId == departmentId).ToListAsync();
        }

        public List<Department> GetDepartmentsWithDefault()
        {
            var DepartmentCollection = _context.Departments.ToList();
            Department defaultDepartment = new Department() { Id = 0, Name = "Choose a Category" };
            DepartmentCollection.Insert(0, defaultDepartment);
            return DepartmentCollection;
        }

        public async Task<bool> AddAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
