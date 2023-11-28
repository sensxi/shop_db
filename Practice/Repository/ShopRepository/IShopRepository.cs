using Practice.Models;

namespace Practice.Repository.ShopRepository
{
    public interface IShopRepository
    {
        Task<List<Shop>> GetAllAsync();

        Task<Shop> GetAsync(int id);

        Task<bool> ShopHasDepartmentAsync(int id);

        Task<bool> AddAsync(Shop shop);

        Task<bool> UpdateAsync(Shop shop);

        Task<bool> DeleteAsync(int id);

        Task<bool> DubbingCheck(Shop shop);
    }
}
