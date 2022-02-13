namespace GotStuff.ViewModels
{
    public class StockProductDetailsVm
    {
        public int StockProductDetailsId { get; set; }
        public int ProductId { get; set; }
        public int PantryId { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime AcquiredDate { get; set; }
    }
}
