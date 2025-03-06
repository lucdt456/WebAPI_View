using Microsoft.AspNetCore.Mvc;

namespace WebAPIView.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
