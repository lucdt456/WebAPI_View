using Microsoft.EntityFrameworkCore;
using WebAPIView.Data;
using WebAPIView.Models.DTOModel;
using WebAPIView.Models.ViewModels;
using WebAPIView.Repositories.Interfaces;

namespace WebAPIView.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ShopDbContext _context;
		public ProductRepository(ShopDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<ProductVM>> GetProducts()
		{
			List<Product> products = await _context.Products.Include(p => p.Brand).Include(p => p.Category).ToListAsync();
			var productVMs = products.Select(p => new ProductVM
			{
				Id = p.Id,
				Name = p.Name,
				Price = p.Price,
				Image = p.Image,
				Quantity = p.Quantity,
				Brand = p.Brand.Name,
				Category = p.Category.Name,
				Description = p.Description
			});
			return productVMs;
		}

		public async Task<Product?> GetProductById(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product != null) return product; else return null;

		}

		public async Task<Product> AddProduct(ProductDTO newProduct)
		{
			var product = new Product
			{
				Name = newProduct.Name,
				Price = newProduct.Price,
				Image = newProduct.Image,
				Quantity = newProduct.Quantity,
				BrandId = newProduct.BrandId,
				CategoryId = newProduct.CategoryId,
				Description = newProduct.Description
			};
			_context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
			return product;
		}


		public async Task<Product?> UpdateProduct(int id, ProductDTO productUpdate)
		{
			var product = await _context.Products.FindAsync(id);

			if (product != null)
			{
				product.Name = productUpdate.Name ?? product.Name;
				product.Price = productUpdate.Price ?? product.Price;
				product.Image = productUpdate.Image ?? product.Image;
				product.Quantity = productUpdate.Quantity ?? product.Quantity;
				product.BrandId = productUpdate.BrandId ?? product.BrandId;
				product.CategoryId = productUpdate.CategoryId ?? product.CategoryId;
				product.Description = productUpdate.Description ?? product.Description;


				_context.Products.Update(product);
				await _context.SaveChangesAsync();

				return product;
			}
			else return null;
		}

		public async Task<bool> DeleteProduct(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product != null)
			{
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
				return true;
			}
			else return false;

		}

		public async Task<string> GetBrandName(int brandId)
		{
			return await _context.Brands.Where(o => o.Id == brandId).Select(o => o.Name).FirstOrDefaultAsync();
		}

		public async Task<string> GetCategoryName(int categoryId)
		{
			return await _context.Categories.Where(o => o.Id == categoryId).Select(o => o.Name).FirstOrDefaultAsync();
		}
	}
}
