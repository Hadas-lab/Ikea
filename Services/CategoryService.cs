using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddCategory(Category newCantegory)
        {
            return await _categoryRepository.AddCategory(newCantegory);
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }

    }
}
