namespace KTJewelry.Models
{
    public class Bracelet : Jewelry
    {
        public string Perimeter { get; set; }

        public override string Type => "Perimeter";
    }
}
