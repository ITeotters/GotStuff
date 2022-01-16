namespace GotStuff.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public StockItem()
        {

        }
    }
}
