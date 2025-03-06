using Microsoft.AspNetCore.Mvc;

namespace WebAPIView.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
