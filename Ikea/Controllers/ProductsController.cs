﻿using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ikea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        } 


        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get([FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] string? userInput, [FromQuery] List<int> categoryIds )
        {
            List<Product> products = await _productService.GetAllProducts(minPrice,maxPrice,userInput, categoryIds);
            return products == null ? NoContent() : Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product newProduct)
        {
            return await _productService.AddProduct(newProduct);
        }

    }
}
