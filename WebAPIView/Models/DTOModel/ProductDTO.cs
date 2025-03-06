using System.ComponentModel.DataAnnotations;

namespace WebAPIView.Models.DTOModel
{
	public class ProductDTO
	{
		[Required(ErrorMessage = "Yêu cầu nhập tên sản phẩm")]
		public string Name { get; set; }
		public double? Price { get; set; }
		public string? Image { get; set; }
		public int? Quantity { get; set; }
		public int? BrandId { get; set; }
		public int? CategoryId { get; set; }
		public string? Description { get; set; }
	}
}
