using Practice.Models;

namespace Practice.Services.DepartmentService
{
    public interface IDepartmentService
    {
        
        Task<List<Department>> GetAllAsync();

        Task<Department> GetAsync(int id);

        Task<List<Department>> GetAllAsync(int shopId);

        List<Shop> GetShopWithDefault();

        Task<bool> DepartmentHasProductsAsync(int departmentId);

        Task<bool> AddAsync(Department department);

        Task<bool> UpdateAsync(Department department);

        Task<bool> DeleteAsync(int departmentId);
    }
}
