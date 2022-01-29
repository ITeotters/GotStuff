namespace GotStuff.Models
{
    public class KnownProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DefaultShelfLife { get; set; }

        public KnownProduct()
        {

        }
    }
}
