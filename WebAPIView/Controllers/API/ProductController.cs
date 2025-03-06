using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using WebAPIView.Data;
using WebAPIView.Models.DTOModel;
using WebAPIView.Models.ViewModels;
using WebAPIView.Services;

namespace WebAPIView.Controllers.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{

		private readonly ProductService _productService;
		public ProductController(ProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<IEnumerable<Product>> GetProducts()
		{
			return await _productService.GetProducts();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProduct(int id)
		{
			var product = await _productService.GetProductById(id);
			if (product != null) return Ok(product);
			else return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> AddProduct(ProductDTO newProduct)
		{
			return Ok(await _productService.AddProduct(newProduct));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProduct(int id, ProductDTO productUpdate)
		{
			var updateProduct = await _productService.UpdateProduct(id, productUpdate);
			if (updateProduct != null) return Ok(updateProduct);
			else return NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var deleteProduct = await _productService.DeleteProduct(id);
			if(deleteProduct) {
				return Ok("Xoá thành công");
			} return NotFound();
		}
	}
}
