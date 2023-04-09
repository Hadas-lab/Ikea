using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IkeaContext _ikeaContext;
        public CategoryRepository(IkeaContext ikeaContext)
        {
            _ikeaContext = ikeaContext;
        }

        public async Task<Category> AddCategory(Category newCantegory)
        {
            await _ikeaContext.Categories.AddAsync(newCantegory);
            await _ikeaContext.SaveChangesAsync();
            return newCantegory;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _ikeaContext.Categories.ToListAsync();
        }
    }
}
