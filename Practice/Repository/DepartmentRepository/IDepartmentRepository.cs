using Practice.Models;

namespace Practice.Repository.DepartmentRepository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();

        Task<Department> GetAsync(int id);

        Task<List<Department>> GetAllAsync(int shopId);

        List<Shop> GetShopWithDefault();

        Task<bool> DepartmentHasProductsAsync(int id);

        Task<bool> AddAsync(Department department);

        Task<bool> EditAsync(Department department);

        Task<bool> DeleteAsync(int id);

        Task<bool> DubbingCheck(Department department);
    }
}
