namespace GotStuff.Models
{
    public class KnownProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultShelfLife { get; set; } = 60;

        public KnownProducts()
        {

        }
    }
}
