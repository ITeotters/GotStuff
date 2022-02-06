namespace GotStuff.ViewModels
{
    public class StockProductGroupVm
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public List<DetailedStockProductVm> StockProducts { get; set; }
    }
}
