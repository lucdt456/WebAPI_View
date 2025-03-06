using Microsoft.EntityFrameworkCore;

namespace WebAPIView.Data
{
	public class ShopDbContext: DbContext
	{
		public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

		public DbSet<Brand>? Brands { get; set; }
		public DbSet<Category>? Categories { get; set; }
		public DbSet<Product>? Products { get; set; }
	}
}
