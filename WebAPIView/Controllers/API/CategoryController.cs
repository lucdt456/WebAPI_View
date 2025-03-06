using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIView.Data;
using WebAPIView.Models.ViewModels;
using WebAPIView.Services.Interfaces;

namespace WebAPIView.Controllers.API
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

		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{
			var category = await _categoryService.GetAllCategoriesAsync();
			return Ok(category);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategoryById(int id)
		{
			var getcategory = await _categoryService.GetCategoryByIdAsync(id);
			if (getcategory == null) return NotFound();
			else return Ok(getcategory);
		}

		[HttpPost]
		public async Task<IActionResult> PostCategory(CategoryVM Newcategory)
		{
			await _categoryService.AddCategoryAsync(Newcategory);
			return Ok(Newcategory);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCategory(int id, CategoryVM categoryUpdate)
		{
			var updatecategory = await _categoryService.UpdateCategoryAsync(id, categoryUpdate);
			if (updatecategory == null) return NotFound();
			else return Ok(updatecategory);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			await _categoryService.DeleteAsync(id);
			return Ok("Xoá Thành công");
		}

	}
}
