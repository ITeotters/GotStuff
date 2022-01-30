namespace GotStuff.ViewModels
{
    public class StockDetailsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime AcquiredDate { get; set; }

        public StockDetailsVm()
        {

        }
    }
}
