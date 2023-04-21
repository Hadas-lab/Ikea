using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IkeaContext _ikeaContext;

        public ProductRepository(IkeaContext ikeaContext)
        {
            _ikeaContext = ikeaContext;
        }

        public async Task<Product> AddProduct(Product newProduct)
        {
            await _ikeaContext.Products.AddAsync(newProduct);
            await _ikeaContext.SaveChangesAsync();
            return newProduct;
        }
        
        public async Task<List<Product>> GetAllProducts(int? minPrice, int? maxPrice, string? userInput, int[] categoryIds)
        {
            var query = _ikeaContext.Products.Where(product =>
                (minPrice == null || product.Price >= minPrice) &&
                (maxPrice == null || product.Price <= maxPrice) &&
                (userInput == null || product.Description.Contains(userInput)) &&
                (categoryIds.Length == 0 || categoryIds.Contains(product.Category.Id))
            );
            return await query.ToListAsync();
        }
    }
}
