using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IStockProductService
    {
        Task<StockProductGroupVm> FindGroupByProductId(int? id);
        Task<List<StockProductDetailsVm>> GetAllStockByProductId(int? id);
        Task<StockProductDetailsVm> FindStockProductById(int? id);
        Task<StockProductDetailsVm> DeleteStockProduct(int? id);
        Task AddNewProduct(int id);
        Task<List<StockProductGroupVm>> GetStockOverviewIncludingZeroCount();
    }
}
