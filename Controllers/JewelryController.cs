using KTJewelry.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static KTJewelry.Models.Jewelry;

namespace KTJewelry.Controllers
{
    public class JewelryController : Controller
    {
        protected List<Jewelry> GetJewelryCollection()
        {
            return new List<Jewelry>
            {
                new Ring { Id = 1, Name = "Gold Ring", Material = Ring.MaterialType.Gold, Price = 20.00M, ImageUrl = "/images/GoldRing1.jpeg", Size = "6" },
                new Necklace { Id = 2, Name = "Silver Necklace", Material = Necklace.MaterialType.Silver, Price = 30.00M, ImageUrl = "/images/SilverNecklace1.jpeg", Length = "12" },
                new Bracelet { Id = 3, Name = "Gold Bracelet", Material = Bracelet.MaterialType.Gold, Price = 20.00M, ImageUrl = "/images/GoldBracelet1.jpeg", Perimeter = "17" },
                new Ring { Id = 4, Name = "Silver Ring", Material = Ring.MaterialType.Silver, Price = 199.99M, ImageUrl = "/images/SilverRing1.jpeg", Size = "6" },
                new Necklace { Id = 5, Name = "Gold Necklace", Material = Necklace.MaterialType.Gold, Price = 20.00M, ImageUrl = "/images/GoldNecklace1.jpeg", Length = "18" },
                new Bracelet { Id = 6, Name = "Silver Bracelet", Material = Bracelet.MaterialType.Silver, Price = 30.00M, ImageUrl = "/images/SilverBracelet1.jpeg", Perimeter = "16" },
                new Ring { Id = 7, Name = "Gold Ring", Material = Ring.MaterialType.Gold, Price = 20.00M, ImageUrl = "/images/GoldRing2.jpeg", Size = "8" },
                new Necklace { Id = 8, Name = "Silver Necklace", Material = Necklace.MaterialType.Silver, Price = 30.00M, ImageUrl = "/images/SilverNecklace2.jpeg", Length = "20" },
                new Bracelet { Id = 9, Name = "Gold Bracelet", Material = Bracelet.MaterialType.Gold, Price = 20.00M, ImageUrl = "/images/GoldBracelet2.jpeg", Perimeter = "12" },
                new Ring { Id = 10, Name = "Silver Ring", Material = Ring.MaterialType.Silver, Price = 30.00M, ImageUrl = "/images/SilverRing2.jpeg", Size = "10" },
                new Necklace { Id = 11, Name = "Gold Necklace", Material = Necklace.MaterialType.Gold, Price = 20.00M, ImageUrl = "/images/GoldNecklace2.jpeg", Length = "17" },
                new Bracelet { Id = 12, Name = "Silver Bracelet", Material = Bracelet.MaterialType.Silver, Price = 30.00M, ImageUrl = "/images/SilverBracelet2.jpeg", Perimeter = "12" },
                new Ring { Id = 13, Name = "Gold Ring", Material = Ring.MaterialType.Gold, Price = 30.00M, ImageUrl = "/images/GoldRing3.jpeg", Size = "10" },
                new Necklace { Id = 14, Name = "Gold Necklace", Material = Necklace.MaterialType.Gold, Price = 20.00M, ImageUrl = "/images/GoldNecklace3.jpeg", Length = "10" },
                new Bracelet { Id = 15, Name = "Silver Bracelet", Material = Bracelet.MaterialType.Silver, Price = 30.00M, ImageUrl = "/images/SilverBracelet3.jpeg", Perimeter = "12" },
                new Ring { Id = 16, Name = "Silver Ring", Material = Ring.MaterialType.Silver, Price = 30.00M, ImageUrl = "/images/SilverRing3.jpeg", Size = "8" },
                new Necklace { Id = 17, Name = "Gold Necklace", Material = Necklace.MaterialType.Gold, Price = 20.00M, ImageUrl = "/images/GoldNecklace4.jpeg", Length = "12" },
                new Bracelet { Id = 18, Name = "Silver Bracelet", Material = Bracelet.MaterialType.Silver, Price = 30.00M, ImageUrl = "/images/SilverBracelet4.jpeg", Perimeter = "11" }
            };
        }

        virtual public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCollections(string type)
        {
            var jewelryCollection = GetJewelryCollection();

            return View("JewelryCollection", jewelryCollection);
        }

        public IActionResult GetCollectionByType(string type)
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

        public IActionResult FilterByUserSelection(string material, string size, string length, string perimeter)
        {
            var jewelryCollection = GetJewelryCollection();

            if (!string.IsNullOrEmpty(material))
            {
                if (Enum.TryParse<MaterialType>(material, true, out var selectedMaterial))
                {
                    jewelryCollection = jewelryCollection
                        .Where(j => j.Material == selectedMaterial)
                        .ToList();
                }
            }

            if (!string.IsNullOrEmpty(size))
            {
                jewelryCollection = jewelryCollection
                    .Where(j => j is Ring ring && ring.Size == size)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(length))
            {
                jewelryCollection = jewelryCollection
                    .Where(j => j is Necklace necklace && necklace.Length == length)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(perimeter))
            {
                jewelryCollection = jewelryCollection
                    .Where(j => j is Bracelet bracelet && bracelet.Perimeter == perimeter)
                    .ToList();
            }

            return View("JewelryCollection", jewelryCollection);
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

	}
}

