using WebAPIView.Data;
using WebAPIView.Models.ViewModels;

namespace WebAPIView.Services.Interfaces
{
	public interface ICategoryService
	{
		Task<IEnumerable<Category>> GetAllCategoriesAsync();
		Task<Category?> GetCategoryByIdAsync(int id);
		Task AddCategoryAsync(CategoryVM newcategory);
		Task<Category?> UpdateCategoryAsync(int id, CategoryVM categoryUpdate);
		Task DeleteAsync(int id);
	}
}
