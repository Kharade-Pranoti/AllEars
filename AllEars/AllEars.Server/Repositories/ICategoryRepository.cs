using AllEars.Server.Entities;

namespace AllEars.Server.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int category_id);
        Task<bool> CreateCategory(Category category);
        Task<bool> UpdateCategory(int id, Category category);
        Task<bool> DeleteCategory(int category_id);
    }
}
