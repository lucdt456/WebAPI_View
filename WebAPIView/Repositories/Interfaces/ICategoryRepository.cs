using WebAPIView.Data;
using WebAPIView.Models.ViewModels;

namespace WebAPIView.Repositories.Interfaces
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAllCategoriesAsync();
		Task<Category?> GetCategoryByIdAsync(int id);
		Task AddCategoryAsync(CategoryVM NewCategory);
		Task<Category?> UpdateCategoryAsync(int id, CategoryVM categoryUpdate);
		Task DeleteAsync(int id);
	}
}
