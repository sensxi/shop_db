using Microsoft.EntityFrameworkCore;
using Practice.Data;
using Practice.Models;
using Practice.Repository.DepartmentRepository;

namespace Practice.Repository.DepartmentRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.Include(t => t.Shop).ToListAsync();
        }

        public async Task<Department> GetAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<List<Department>> GetAllAsync(int shopId)
        {
            return await _context.Departments.Where(g => g.ShopId == shopId).ToListAsync();
        }

        public List<Shop> GetShopWithDefault()
        {
            var shopCollection = _context.Shops.ToList();
            Shop defaultShop = new Shop() { Id = 0, Name = "Choose a Category" };
            shopCollection.Insert(0, defaultShop);
            return shopCollection;
        }

        public async Task<bool> DepartmentHasProductsAsync(int id)
        {
            return await _context.Products.AnyAsync(s => s.DepartmentId == id);
        }

        public async Task<bool> AddAsync(Department department)
        {
            if (await DubbingCheck(department))
                return false;

            _context.Add(department);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditAsync(Department department)
        {
            if (await DubbingCheck(department))
                return false;

            _context.Update(department);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DubbingCheck(Department department)
        {
            return await _context.Departments.AnyAsync(c => c.Name == department.Name && c.ShopId == department.ShopId);
        }
    }
}
