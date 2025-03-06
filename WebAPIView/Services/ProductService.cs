using WebAPIView.Data;
using WebAPIView.Models.DTOModel;
using WebAPIView.Models.ViewModels;
using WebAPIView.Repositories;
using WebAPIView.Services.Interfaces;

namespace WebAPIView.Services
{
	public class ProductService : IProductService
	{
		private readonly ProductRepository _productRepository;
		public ProductService(ProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<IEnumerable<Product>> GetProducts()
		{
			return await _productRepository.GetProducts();
		}

		public async Task<ProductVM?> GetProductById(int id)
		{
			var getProductById = await _productRepository.GetProductById(id);
			var brandName = await _productRepository.GetBrandName((int)getProductById.BrandId);
			var categoryName = await _productRepository.GetCategoryName((int)getProductById.CategoryId);
			if (getProductById != null)
			{
				var productVM = new ProductVM
				{
					Id = getProductById.Id,
					Name = getProductById.Name,
					Price = getProductById.Price,
					Image = getProductById.Image,
					Quantity = getProductById.Quantity,
					Brand = brandName,
					Category = categoryName,
					Description = getProductById.Description
				};
				return productVM;
			}
			else return null;
		}

		public async Task<Product> AddProduct(ProductDTO newProduct)
		{
			return await _productRepository.AddProduct(newProduct);
		}


		public async Task<Product?> UpdateProduct(int id, ProductDTO productUpdate)
		{
			var updateProduct = await _productRepository.UpdateProduct(id, productUpdate);
			if (updateProduct != null) return updateProduct;
			else return null;
		}

		public async Task<bool> DeleteProduct(int id)
		{
			return await _productRepository.DeleteProduct(id);
		}
	}
}
