using WebAPIView.Data;
using WebAPIView.Models.ViewModels;
using WebAPIView.Repositories.Interfaces;
using WebAPIView.Services.Interfaces;

namespace WebAPIView.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<IEnumerable<Category?>> GetAllCategoriesAsync()
		{
			return await _categoryRepository.GetAllCategoriesAsync();
		}

		public async Task<Category> GetCategoryByIdAsync(int id)
		{
			return await _categoryRepository.GetCategoryByIdAsync(id);
		}

		public async Task AddCategoryAsync(CategoryVM Newcategory)
		{
			await _categoryRepository.AddCategoryAsync(Newcategory);
		}

		public async Task<Category?> UpdateCategoryAsync(int id, CategoryVM categoryUpdate)
		{
			var updateCategory = await _categoryRepository.UpdateCategoryAsync(id, categoryUpdate);
			return updateCategory;
		}

		public Task DeleteAsync(int id)
		{
			return _categoryRepository.DeleteAsync(id);
		}
	}
}
