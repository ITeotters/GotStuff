namespace GotStuff.ViewModels
{
    public class DetailedStockProductVm
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime AcquiredDate { get; set; }

        public DetailedStockProductVm()
        {

        }
    }
}
