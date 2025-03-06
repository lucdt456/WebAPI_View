using System.ComponentModel.DataAnnotations;

namespace WebAPIView.Models.ViewModels
{
	public class ProductVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double? Price { get; set; }
		public string? Image { get; set; }
		public int? Quantity { get; set; }
		public string? Brand { get; set; }
		public string? Category { get; set; }
		public string? Description { get; set; }	
	}
}
