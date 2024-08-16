using AllEars.Server.Entities;
using AllEars.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllCategories()
        {
            List<Category> categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("getid/{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            Category category = await _categoryService.GetCategoryById(categoryId);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound(new { message = "Category not found." });
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            bool result = await _categoryService.CreateCategory(category);
            if (result)
            {
                // Assuming that category_id is generated and known after creation, or you might need to adjust this
                return CreatedAtAction(nameof(GetCategoryById), new { categoryId = category.category_id }, category);
            }
            return BadRequest(new { message = "Failed to create category." });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            bool result = await _categoryService.UpdateCategory(id, category);
            if (result)
            {
                return Ok(new { message = "Category updated successfully." });
            }
            return BadRequest(new { message = "Failed to update category." });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            bool result = await _categoryService.DeleteCategory(id);
            if (result)
            {
                return Ok(new { message = "Category deleted successfully." });
            }
            return NotFound(new { message = "Category not found." });
        }
    }
}
