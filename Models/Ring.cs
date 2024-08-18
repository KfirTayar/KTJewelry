namespace KTJewelry.Models
{
    public class Ring : Jewelry
    {
        public string Size { get; set; }

        public override string Type => "Ring";
    }
}
