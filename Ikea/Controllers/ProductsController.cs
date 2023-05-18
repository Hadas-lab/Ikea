using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;

namespace Ikea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        } 


        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get([FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] string? userInput, [FromQuery] List<int> categoryIds )
        {
            List<Product> products = await _productService.GetAllProducts(minPrice,maxPrice,userInput, categoryIds);
            List<ProductDto> productDtos = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return productDtos == null ? NoContent() : Ok(productDtos);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post([FromBody] ProductDto newProductDto)
        {
            
            Product newProduct = _mapper.Map<ProductDto, Product>(newProductDto);
            Product p =  await _productService.AddProduct(newProduct);
            return _mapper.Map<Product, ProductDto>(p);
        }

    }
}
