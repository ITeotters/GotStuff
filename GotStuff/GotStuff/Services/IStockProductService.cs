using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IStockProductService
    {
        Task<List<StockProductGroupVm>> GetOverviewOfStock();
        Task<StockProductGroupVm> FindGroupByProductId(int? id);
        Task<List<DetailedStockProductVm>> GetAllStockByProductId(int? id);
        Task<DetailedStockProductVm> FindStockProductById(int? id);
        Task<DetailedStockProductVm> DeleteStockProduct(int? id);
        Task AddNewProduct(int id);
    }
}
