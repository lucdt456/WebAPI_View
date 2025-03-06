using WebAPIView.Data;
using WebAPIView.Models.DTOModel;
using WebAPIView.Models.ViewModels;

namespace WebAPIView.Services.Interfaces
{
	public interface IProductService
	{
		Task<IEnumerable<ProductVM>> GetProducts();
		Task<ProductVM?> GetProductById(int id);
		Task<Product> AddProduct(ProductDTO newProduct);
		Task<Product?> UpdateProduct(int id, ProductDTO productUpdate);
		Task<bool> DeleteProduct(int id);
	}
}
