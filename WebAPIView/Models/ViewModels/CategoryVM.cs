using System.ComponentModel.DataAnnotations;

namespace WebAPIView.Models.ViewModels
{
	public class CategoryVM
	{
		[Required(ErrorMessage = "Yêu cầu nhập tên loại sản phẩm")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập mô tả loại sản phẩm")]
		public string Description { get; set; }
	}
}
