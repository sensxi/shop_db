using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.Models;
using Practice.Repository.DepartmentRepository;
using Practice.Data;
using Practice.Repository.DepartmentRepository;
using Practice.Services.DepartmentService;

namespace Practice.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository ;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<Department> GetAsync(int id)
        {
            return await _departmentRepository.GetAsync(id);
        }

        public async Task<List<Department>> GetAllAsync(int shopId)
        {
            return await _departmentRepository.GetAllAsync(shopId);
        }

        public List<Shop> GetShopWithDefault()
        {
            return _departmentRepository.GetShopWithDefault();
        }

        public async Task<bool> DepartmentHasProductsAsync(int id)
        {
            return await _departmentRepository.DepartmentHasProductsAsync(id);
        }

        public async Task<bool> AddAsync(Department department)
        {
            return await _departmentRepository.AddAsync(department);
        }

        public async Task<bool> UpdateAsync(Department department)
        {
            return await _departmentRepository.EditAsync(department);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hasProduct = await _departmentRepository.DepartmentHasProductsAsync(id);
            if (hasProduct)
            {
                return false;
            }
            return await _departmentRepository.DeleteAsync(id);
        }
    }
}
