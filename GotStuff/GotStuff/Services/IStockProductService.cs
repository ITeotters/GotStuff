using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IStockProductService
    {
        Task<StockProductGroupVm> FindGroupByProductId(int? id);
        Task<List<StockProductDetailsVm>> GetAllStockByProductId(int? id);
        Task<StockProductDetailsVm> FindStockProductVmById(int? id);
        Task<StockProductDetailsVm> DeleteStockProduct(int? id);
        Task AddNewProduct(int knownProductId);
        Task<List<StockProductGroupVm>> GetStockOverviewIncludingZeroCount();
        Task EditStockProduct(StockProductDetailsVm stockProductToEdit);
    }
}
