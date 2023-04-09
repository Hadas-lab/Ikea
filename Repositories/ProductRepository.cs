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
        
        //public async Task<List<Product>> GetAllProducts(string name, List<int> categoriesId, int minPrice, int maxPrice)
        public async Task<List<Product>> GetAllProducts()
        {
            //List<Product> products = await _ikeaContext.Products.ToListAsync();
            //products = products.FindAll(p => p.Price > minPrice && p.Price < maxPrice);
            return  await _ikeaContext.Products.Include(p => p.Category).ToListAsync();
        }
    }
}
