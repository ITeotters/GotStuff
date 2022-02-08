namespace GotStuff.ViewModels
{
    public class StockProductDetailsVm
    {
        public int StockProductDetailesId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime AcquiredDate { get; set; }
    }
}
