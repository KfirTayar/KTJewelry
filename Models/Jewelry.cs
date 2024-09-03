namespace KTJewelry.Models
{
    public abstract class Jewelry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public MaterialType Material { get; set; }

        public enum MaterialType
        {
            Gold,
            Silver
        }

        public abstract string Type { get; }

        public int Quantity { get; set; } = 1;

        public Jewelry(int id, string name, decimal price, string imageUrl, MaterialType material) { 

            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.ImageUrl = imageUrl;
            this.Material = material;

        }
    }
}
