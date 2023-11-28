using Practice.Models;

namespace Practice.Repository.ProductRepository
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);

        Task<List<Product>> GetAllAsync();

        Task<List<Product>> GetAllAsync(int departmentId);

        List<Department> GetDepartmentsWithDefault();

        Task<bool> AddAsync(Product product);

        Task<bool> UpdateAsync(Product product);

        Task<bool> DeleteAsync(int id);
    }
}
