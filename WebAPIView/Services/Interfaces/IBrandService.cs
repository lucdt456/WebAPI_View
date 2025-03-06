using WebAPIView.Data;
using WebAPIView.Models.ViewModels;

namespace WebAPIView.Services.Interfaces
{
	public interface IBrandService
	{
			Task<IEnumerable<Brand>> GetBrandsAsync();
			Task<Brand> GetBrandByIdAsync(int id);
			Task CreateBrandAsync(BrandVM model);
			Task UpdateBrandByIdAsync(int id, BrandVM model);
			Task DeleteBrandByIdAsync(int id);	

	}
}
