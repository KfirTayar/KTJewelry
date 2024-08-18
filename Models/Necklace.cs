namespace KTJewelry.Models
{
    public class Necklace : Jewelry
    {
        public string Length { get; set; }

        public override string Type => "Length";
    }
}
