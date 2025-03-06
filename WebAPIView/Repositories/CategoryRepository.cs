using Microsoft.EntityFrameworkCore;
using WebAPIView.Data;
using WebAPIView.Models.ViewModels;
using WebAPIView.Repositories.Interfaces;

namespace WebAPIView.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ShopDbContext _context;
		public CategoryRepository(ShopDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<Category?> GetCategoryByIdAsync(int id)
		{
			var category = await _context.Categories.FindAsync(id);
			if (category != null) return (category);
			else return null;
		}

		public async Task AddCategoryAsync(CategoryVM Newcategory)
		{
			var category = new Category
			{
				Name = Newcategory.Name,
				Description = Newcategory.Description
			};

			_context.Categories.Add(category);
			await _context.SaveChangesAsync();
		}

		public async Task<Category?> UpdateCategoryAsync(int id,CategoryVM categoryUpdate)
		{
			var category = await _context.Categories.FindAsync(id);
			if (category != null)
			{
				category.Name = categoryUpdate.Name;
				category.Description = categoryUpdate.Description;
				_context.Categories.Update(category);
				await _context.SaveChangesAsync();
				return (category);
			}
			else return null;
		}

		public async Task DeleteAsync(int id)
		{
			var category = await _context.Categories.FirstOrDefaultAsync(o => o.Id == id);
				_context.Categories.Remove(category);
				await _context.SaveChangesAsync();
		}
	}
}
