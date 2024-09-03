using System.Transactions;

namespace KTJewelry.Models
{
    public class Ring : Jewelry
    {
        public string Size { get; set; }

        public override string Type => "Ring";

        public Ring(int id, string name, decimal price, string imageUrl, MaterialType material, string size) : base(id, name, price, imageUrl, material) { 
            
            this.Size = size;
        }
    }
}
