using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product newProduct);
        Task<List<Product>> GetAllProducts(int? minPrice,int? maxPrice, string? userInput, List<int> categoryIds);
    }
}