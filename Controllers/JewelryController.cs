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
                new Ring(1, "Gold Ring", 20.00M, "/images/GoldRing1.jpeg", Jewelry.MaterialType.Gold, "6"),
                new Necklace(2, "Silver Necklace", 30.00M, "/images/SilverNecklace1.jpeg", Jewelry.MaterialType.Silver, "12"),
                new Bracelet(3, "Gold Bracelet", 20.00M, "/images/GoldBracelet1.jpeg", Jewelry.MaterialType.Gold, "17"),
                new Ring(4, "Silver Ring", 50.00M, "/images/SilverRing1.jpeg", Jewelry.MaterialType.Silver, "6"),
                new Necklace(5, "Gold Necklace", 20.00M, "/images/GoldNecklace1.jpeg", Jewelry.MaterialType.Gold, "18"),
                new Bracelet(6, "Silver Bracelet", 30.00M, "/images/SilverBracelet1.jpeg", Jewelry.MaterialType.Silver, "16"),
                new Ring(7, "Gold Ring", 20.00M, "/images/GoldRing2.jpeg", Jewelry.MaterialType.Gold, "8"),
                new Necklace(8, "Silver Necklace", 30.00M, "/images/SilverNecklace2.jpeg", Jewelry.MaterialType.Silver, "20"),
                new Bracelet(9, "Gold Bracelet", 20.00M, "/images/GoldBracelet2.jpeg", Jewelry.MaterialType.Gold, "12"),
                new Ring(10, "Silver Ring", 30.00M, "/images/SilverRing2.jpeg", Jewelry.MaterialType.Silver, "10"),
                new Necklace(11, "Gold Necklace", 20.00M, "/images/GoldNecklace2.jpeg", Jewelry.MaterialType.Gold, "17"),
                new Bracelet(12, "Silver Bracelet", 30.00M, "/images/SilverBracelet2.jpeg", Jewelry.MaterialType.Silver, "12"),
                new Ring(13, "Gold Ring", 30.00M, "/images/GoldRing3.jpeg", Jewelry.MaterialType.Gold, "10"),
                new Necklace(14, "Gold Necklace", 20.00M, "/images/GoldNecklace3.jpeg", Jewelry.MaterialType.Gold, "10"),
                new Bracelet(15, "Silver Bracelet", 30.00M, "/images/SilverBracelet3.jpeg", Jewelry.MaterialType.Silver, "12"),
                new Ring(16, "Silver Ring", 30.00M, "/images/SilverRing3.jpeg", Jewelry.MaterialType.Silver, "8"),
                new Necklace(17, "Gold Necklace", 20.00M, "/images/GoldNecklace4.jpeg", Jewelry.MaterialType.Gold, "12"),
                new Bracelet(18, "Silver Bracelet", 30.00M, "/images/SilverBracelet4.jpeg", Jewelry.MaterialType.Silver, "11")
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

