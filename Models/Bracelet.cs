namespace KTJewelry.Models
{
    public class Bracelet : Jewelry
    {
        public string Perimeter { get; set; }

        public override string Type => "Perimeter";

        public Bracelet(int id, string name, decimal price, string imageUrl, MaterialType material, string perimeter) : base(id, name, price, imageUrl, material) { 
            
            this.Perimeter = perimeter;
        }
    }
}
