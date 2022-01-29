namespace GotStuff.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int KnownProductId { get; set; }
        public KnownProduct KnownProduct { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime AcquiredDate { get; set; }

        public Stock()
        {

        }
    }
}
