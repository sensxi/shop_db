using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.Models;
using Practice.Repository.ShopRepository;
using Practice.Data;
using Practice.Repository.ShopRepository;

namespace Practice.Services.ShopService
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<List<Shop>> GetAllAsync()
        {
            return await _shopRepository.GetAllAsync();
        }

        public async Task<Shop> GetAsync(int id)
        {
            return await _shopRepository.GetAsync(id);
        }

        public async Task<bool> AddAsync(Shop shop)
        {
            return await _shopRepository.AddAsync(shop);
        }

        public async Task<bool> UpdateAsync(Shop shop)
        {
            return await _shopRepository.UpdateAsync(shop);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hasDepartment = await _shopRepository.ShopHasDepartmentAsync(id);
            if (hasDepartment)
            {
                return false;
            }
            return await _shopRepository.DeleteAsync(id);
        }

        public async Task<bool> ShopHasDepartmentAsync(int id)
        {
            return await _shopRepository.ShopHasDepartmentAsync(id);
        }
    }
}
