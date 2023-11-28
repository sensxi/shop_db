using Microsoft.EntityFrameworkCore;
using Practice.Models;
using Practice.Repository.ProductRepository;
using Practice.Data;
using Practice.Repository.ProductRepository;
using Practice.Services.ProductService;

namespace Practice.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _productRepository.GetAsync(id);
        }

        public async Task<List<Product>> GetAllAsync(int departmentId)
        {
            return await _productRepository.GetAllAsync(departmentId);
        }

        public List<Department> GetDepartmentWithDefault()
        {
            return _productRepository.GetDepartmentsWithDefault();
        }

        public async Task<bool> AddAsync(Product product)
        {
           return await _productRepository.AddAsync(product);
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }



    }
}
