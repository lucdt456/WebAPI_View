using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIView.Data
{
	[Table("Products")]
	public class Product
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập tên sản phẩm")]
		public string Name { get; set; }
		public double? Price { get; set; }
		public string? Image { get; set; }
		public int?  Quantity { get; set; }
		public string? Description { get; set; }

		[ForeignKey("BrandId")]
		public int? BrandId { get; set; }
		public Brand Brand { get; set; }

		[ForeignKey("CategoryId")]
		public int? CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
