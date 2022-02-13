namespace GotStuff.ViewModels
{
    public class PantryVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<StockProductGroupVm> Contents { get; set; }
    }
}

