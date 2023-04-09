using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product newProduct);
        Task<List<Product>> GetAllProducts();
    }
}