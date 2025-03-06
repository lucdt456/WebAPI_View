using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIView.Data
{
	[Table("Brands")]
	public class Brand
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập tên thương hiệu")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập mô tả thương hiệu")]
		public string Description { get; set; }
		public List<Product> Products { get; set; } = new List<Product>();
	}
}
