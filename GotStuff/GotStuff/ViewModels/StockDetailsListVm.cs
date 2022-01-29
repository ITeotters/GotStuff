namespace GotStuff.ViewModels
{
    public class StockDetailsListVm
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime AcquiredDate { get; set; }

        public StockDetailsListVm()
        {

        }
    }
}
