using AllEars.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<List<Category>> GetAllCategories()
        {
            using (var context = new AllEarsContext())
            {
                var categories = from category in context.Categories
                                 select category;
                return await categories.ToListAsync();
            }
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            using (var context = new AllEarsContext())
            {
                var category = await context.Categories.FindAsync(categoryId);

                // Optionally handle the case where category is not found
                if (category == null)
                {
                    return null;
                }

                return category;
            }
        }

        public async Task<bool> CreateCategory(Category category)
        {
            using (var context = new AllEarsContext())
            {
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateCategory(int id, Category category)
        {
            using (var context = new AllEarsContext())
            {
                var cat = await context.Categories.FindAsync(id);
                if (cat == null)
                {
                    return false; // Or throw an exception if not found
                }

                cat.category_name = category.category_name;

                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            using (var context = new AllEarsContext())
            {
                var category = await context.Categories.FindAsync(categoryId);
                if (category == null)
                {
                    return false; // Category not found, return false
                }

                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return true; // Deletion successful
            }
        }

    }
}

