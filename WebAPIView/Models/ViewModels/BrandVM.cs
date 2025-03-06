using System.ComponentModel.DataAnnotations;

namespace WebAPIView.Models.ViewModels
{
	public class BrandVM
	{
		[Required(ErrorMessage = "Yêu cầu nhập tên thương hiệu")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập mô tả thương hiệu")]
		public string Description { get; set; }
	}
}
