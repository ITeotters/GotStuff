using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IStockProductService
    {
        Task<List<StockProductVm>> GetOverviewOfStock();
    }
}
