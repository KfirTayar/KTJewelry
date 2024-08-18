using KTJewelry.Models;
using Microsoft.AspNetCore.Mvc;

namespace KTJewelry.Controllers
{
    public class CartController : JewelryController
    {

        // In-memory cart for demo purposes
        private static List<Jewelry> cart = new List<Jewelry>();

        public IActionResult Main()
        {
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            // Retrieve the item by id (you might want to fetch this from your jewelry collection)
            var jewelryCollection = GetJewelryCollection();
            var item = jewelryCollection.FirstOrDefault(j => j.Id == id);

            if (item != null)
            {
                cart.Add(item);
            }

            return RedirectToAction("Main");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var item = cart.FirstOrDefault(j => j.Id == id);
            if (item != null)
            {
                cart.Remove(item);
            }

            return RedirectToAction("Main");
        }
    }
}
