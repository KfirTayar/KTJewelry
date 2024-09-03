namespace KTJewelry.Models
{
    public class Necklace : Jewelry
    {
        public string Length { get; set; }

        public override string Type => "Length";

        public Necklace(int id, string name, decimal price, string imageUrl, MaterialType material, string length) : base(id, name, price, imageUrl, material){

            this.Length = length;
        }
    }
}
