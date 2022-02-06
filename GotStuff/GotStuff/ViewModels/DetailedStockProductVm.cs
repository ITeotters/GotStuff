namespace GotStuff.ViewModels
{
    public class DetailedStockProductVm
    {
        public int DetailedStockProductId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime AcquiredDate { get; set; }
    }
}
