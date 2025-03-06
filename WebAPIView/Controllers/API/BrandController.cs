using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIView.Data;
using WebAPIView.Models.ViewModels;

namespace WebAPIView.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ShopDbContext _dB;
        public BrandController(ShopDbContext dB)
        {
            _dB = dB;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands() {
            if (_dB.Brands != null)
            {                
                return Ok(await _dB.Brands.ToListAsync());
            }
            else return NotFound();
		}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var brand = await _dB.Brands.FirstOrDefaultAsync(p => p.Id == id);
            if (brand != null)
            {
                return Ok(brand);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostBrand(BrandVM model) 
        {
            var brand = new Brand
            {
                Name = model.Name,
                Description = model.Description
            };

            _dB.Add(brand);
            await _dB.SaveChangesAsync();
            return Ok(brand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrandById(int id, BrandVM model)
        {
			var brand = await _dB.Brands.SingleOrDefaultAsync(p => p.Id == id);
            if (brand != null)
            {
                brand.Name = model.Name;
                brand.Description = model.Description;

                await _dB.SaveChangesAsync();
                return Ok(brand);
            }
            else return NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBrandById(int id)
		{
			var brand = await _dB.Brands.SingleOrDefaultAsync(p => p.Id == id);
            if (brand != null)
            {
                _dB.Brands.Remove(brand);
                await _dB.SaveChangesAsync();
                return NoContent();
            }
            else return NotFound();
		}
	}
}
