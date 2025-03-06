using WebAPIView.Data;
using WebAPIView.Models.ViewModels;
using WebAPIView.Repositories.Interfaces;
using WebAPIView.Services.Interfaces;
namespace WebAPIView.Services
{
	public class BrandService : IBrandService
	{
		private readonly IBrandRepository _brandRepository;
		public BrandService(IBrandRepository brandRepository)
		{
			_brandRepository = brandRepository;
		}

		public async Task<IEnumerable<Brand>> GetBrandsAsync()
		{
			return await _brandRepository.GetAllAsync();
		}

		public async Task<Brand> GetBrandByIdAsync(int id)
		{
			return await _brandRepository.GetByIdAsync(id);
		}

		public async Task CreateBrandAsync(BrandVM model)
		{
			var brand = new Brand
			{
				Name = model.Name,
				Description = model.Description
			};
			await _brandRepository.AddAsync(brand);
		}
		public async Task UpdateBrandByIdAsync(int id, BrandVM model)
		{
			var brand = await _brandRepository.GetByIdAsync(id);
			if (brand != null)
			{
				brand.Name = model.Name;
				brand.Description = model.Description;
				await _brandRepository.UpdateAsync(brand);
			}
		}
		public async Task DeleteBrandByIdAsync(int id)
		{
			await _brandRepository.DeleteAsync(id);
		}

	}
}
