using Microsoft.EntityFrameworkCore;
using Practice.Data;
using Practice.Models;
using Practice.Repository.ShopRepository;

namespace Practice.Repository.ShopRepository
{
    public class ShopRepository : IShopRepository
    {
        private readonly ApplicationDbContext _context;

        public ShopRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Shop>> GetAllAsync()
        {
            return await _context.Shops.ToListAsync();
        }

        public async Task<Shop> GetAsync(int id)
        {
            return await _context.Shops.FindAsync(id);
        }

        public async Task<bool> ShopHasDepartmentAsync(int id)
        {
            return await _context.Departments.AnyAsync(s => s.ShopId == id);
        }
        public async Task<bool> AddAsync(Shop shop)
        {
            if (await DubbingCheck(shop))
                return false;

            _context.Add(shop);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateAsync(Shop shop)
        {
            if (await DubbingCheck(shop))
                return false;

            _context.Update(shop);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop != null)
            {
                _context.Shops.Remove(shop);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DubbingCheck(Shop shop)
        {
            return await _context.Shops.AnyAsync(c => c.Name == shop.Name);
        }


    }
}
