using Entities;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category newCantegory);
        Task<List<Category>> GetAllCategories();
    }
}