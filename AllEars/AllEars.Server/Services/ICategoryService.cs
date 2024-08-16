using AllEars.Server.Entities;
namespace AllEars.Server.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int categoryId);
        Task<bool> CreateCategory(Category category);
        Task<bool> UpdateCategory(int id, Category category);
        Task<bool> DeleteCategory(int categoryId);
    }
}
