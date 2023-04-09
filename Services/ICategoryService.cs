using Entities;

namespace Services
{
    public interface ICategoryService
    {
        Task<Category> AddCategory(Category newCantegory);
        Task<List<Category>> GetAllCategories();
    }
}