using Microsoft.AspNetCore.Mvc;

namespace KTJewelry.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
