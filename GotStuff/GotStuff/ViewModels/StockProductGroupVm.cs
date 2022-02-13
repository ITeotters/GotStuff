namespace GotStuff.ViewModels
{
    public class StockProductGroupVm
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int PantryId { get; set; }
        public int Count { get; set; }
        public List<StockProductDetailsVm> StockProducts { get; set; }
    }
}
