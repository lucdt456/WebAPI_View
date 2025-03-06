using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIView.Data
{
	[Table("Categories")]
	public class Category
	{
		[Key]
		public int  Id { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập tên loại sản phẩm")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập mô tả loại sản phẩm")]
		public string Description { get; set; }
		public List<Product> Products { get; set; } = new List<Product>();
	}
}
