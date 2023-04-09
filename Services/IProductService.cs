using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product newProduct);
        Task<List<Product>> GetAllProducts();
    }
}