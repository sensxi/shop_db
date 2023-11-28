using Practice.Models;

namespace Practice.Services.ProductService
{
    public interface IProductService
    {
        Task<Product> GetAsync(int id);

        Task<List<Product>> GetAllAsync();

        Task<List<Product>> GetAllAsync(int departmentId);

        List<Department> GetDepartmentWithDefault();

        Task<bool> AddAsync(Product product);

        Task<bool> UpdateAsync(Product product);

        Task<bool> DeleteAsync(int id);
    }
}
