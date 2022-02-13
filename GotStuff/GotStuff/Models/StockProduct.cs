namespace GotStuff.Models
{
    public class StockProduct
    {
        public int Id { get; set; }
        public int KnownProductId { get; set; }
        public KnownProduct KnownProduct { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime AcquiredDate { get; set; }
        public int PantryId { get; set; }
        public Pantry Pantry { get; set; }

        public StockProduct()
        {

        }
    }
}
