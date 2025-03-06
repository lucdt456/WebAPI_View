using WebAPIView.Data;
using WebAPIView.Models.DTOModel;
namespace WebAPIView.Repositories.Interfaces
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetProducts();
		Task<Product?> GetProductById(int id);
		Task<Product> AddProduct(ProductDTO NewProduct);
		Task<Product?> UpdateProduct(int id, ProductDTO productUpdate);
		Task<bool> DeleteProduct(int id);
		Task<string> GetBrandName(int brandId);
		Task<string> GetCategoryName(int categoryId);
	}
}
