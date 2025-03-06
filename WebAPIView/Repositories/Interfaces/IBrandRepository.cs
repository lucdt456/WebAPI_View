using WebAPIView.Data;

namespace WebAPIView.Repositories.Interfaces
{
	public interface IBrandRepository
	{
		Task<IEnumerable<Brand>> GetAllAsync();
		Task<Brand> GetByIdAsync(int id);
		Task AddAsync(Brand brand);
		Task UpdateAsync(Brand brand);
		Task DeleteAsync(int id);
	}

}
