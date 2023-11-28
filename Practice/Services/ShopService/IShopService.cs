using Practice.Models;

namespace Practice.Services.ShopService
{
    public interface IShopService
    {
        Task<List<Shop>> GetAllAsync();

        Task<Shop> GetAsync(int id);

        Task<bool> AddAsync(Shop shop);

        Task<bool> UpdateAsync(Shop shop);

        Task<bool> DeleteAsync(int id);

        Task<bool> ShopHasDepartmentAsync(int id);
    }
}
