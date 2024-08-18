using KTJewelry.Models;
using Microsoft.AspNetCore.Mvc;

namespace KTJewelry.Controllers
{
    public class JewelryController : Controller
    {
        // Method to get all jewelry items
        private List<Jewelry> GetJewelryCollection()
        {
            return new List<Jewelry>
            {
                new Ring { Id = 1, Name = "Gold Ring", Material = "Gold", Price = 199.99M, ImageUrl = "/images/Ring.png", Size = "6" },
                new Necklace { Id = 2, Name = "Silver Necklace", Material = "Silver", Price = 299.99M, ImageUrl = "/images/Necklace.png", Length = "18 inches" },
                new Bracelet { Id = 3, Name = "Diamond Bracelet", Material = "Diamond", Price = 999.99M, ImageUrl = "/images/Bracelet.png", Perimeter = "7 inches" },
                new Ring { Id = 4, Name = "Gold Ring", Material = "Gold", Price = 199.99M, ImageUrl = "/images/Ring.png", Size = "6" },
                new Necklace { Id = 5, Name = "Silver Necklace", Material = "Silver", Price = 299.99M, ImageUrl = "/images/Necklace.png", Length = "18 inches" },
                new Bracelet { Id = 6, Name = "Diamond Bracelet", Material = "Diamond", Price = 999.99M, ImageUrl = "/images/Bracelet.png", Perimeter = "7 inches" },
                new Ring { Id = 7, Name = "Gold Ring", Material = Ring.MaterialType.Gold, Price = 199.99M, ImageUrl = "/images/Ring.png", Size = "6" },
                new Necklace { Id = 8, Name = "Silver Necklace", Material = "Silver", Price = 299.99M, ImageUrl = "/images/Necklace.png", Length = "18 inches" },
                new Bracelet { Id = 9, Name = "Diamond Bracelet", Material = "Diamond", Price = 999.99M, ImageUrl = "/images/Bracelet.png", Perimeter = "7 inches" },
                new Ring { Id = 10, Name = "Gold Ring", Material = "Gold", Price = 199.99M, ImageUrl = "/images/Ring.png", Size = "6" },
                new Necklace { Id = 11, Name = "Silver Necklace", Material = "Silver", Price = 299.99M, ImageUrl = "/images/Necklace.png", Length = "18 inches" },
                new Bracelet { Id = 12, Name = "Diamond Bracelet", Material = "Diamond", Price = 999.99M, ImageUrl = "/images/Bracelet.png", Perimeter = "7 inches" }
                new Ring { Id = 13, Name = "Gold Ring", Material = "Gold", Price = 199.99M, ImageUrl = "/images/Ring.png", Size = "6" },
                new Necklace { Id = 14, Name = "Silver Necklace", Material = "Silver", Price = 299.99M, ImageUrl = "/images/Necklace.png", Length = "18 inches" },
                new Bracelet { Id = 15, Name = "Diamond Bracelet", Material = "Diamond", Price = 999.99M, ImageUrl = "/images/Bracelet.png", Perimeter = "7 inches" }
                new Ring { Id = 16, Name = "Gold Ring", Material = "Gold", Price = 199.99M, ImageUrl = "/images/Ring.png", Size = "6" },
                new Necklace { Id = 17, Name = "Silver Necklace", Material = "Silver", Price = 299.99M, ImageUrl = "/images/Necklace.png", Length = "18 inches" },
                new Bracelet { Id = 18, Name = "Diamond Bracelet", Material = "Diamond", Price = 999.99M, ImageUrl = "/images/Bracelet.png", Perimeter = "7 inches" }
            };
        }

        public IActionResult JewelryCollection(string type)
        {
            var jewelryCollection = GetJewelryCollection();

            if (!string.IsNullOrEmpty(type))
            {
                jewelryCollection = jewelryCollection
                    .Where(j => j.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View("JewelryCollection", jewelryCollection);
        }
    }
}

