using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Ikea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
           _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            List<Category> products = await _categoryService.GetAllCategories();
            if (products == null)
            {
                return NoContent();
            }
            return Ok(products);
            //return products == null ? Ok(products) : NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category newCategory)
        {
            Category category = await _categoryService.AddCategory(newCategory);
            return category;
        }
    }
}
