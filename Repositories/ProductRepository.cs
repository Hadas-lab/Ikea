using DTO;
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
        private readonly IkeaContext _ikeaContext;


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
        
        public async Task<List<Product>> GetAllProducts(int? minPrice, int? maxPrice, string? userInput, List<int> categoryIds)
        {
            var query = _ikeaContext.Products.Where(product =>
                (minPrice == null || product.Price >= minPrice) &&
                (maxPrice == null || product.Price <= maxPrice) &&
                (userInput == null || product.Description.Contains(userInput) || product.Name.Contains(userInput)) &&
                (categoryIds.Count == 0 || categoryIds.Contains(product.CategoryId))
            ).Include(p => p.Category).OrderByDescending(p => p.Name);
            return await query.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _ikeaContext.Products.FirstAsync(p => p.Id == id);
        }
    }
}
