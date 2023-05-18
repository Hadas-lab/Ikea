using Entities;
using DTO;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product newProduct);
        Task<List<Product>> GetAllProducts(int? minPrice, int? maxPrice, string? userInput, List<int> categoryIds);
        Task<Product> GetProductById(int id);
    }
}