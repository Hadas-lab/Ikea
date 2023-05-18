using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;


        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProduct(Product newProduct)
        {
            return await _productRepository.AddProduct(newProduct);
        }


        public async Task<List<Product>> GetAllProducts(int? minPrice, int? maxPrice, string? userInput, List<int> categoryIds)
        {
            return await _productRepository.GetAllProducts(minPrice, maxPrice, userInput, categoryIds);
        }

    }
}
