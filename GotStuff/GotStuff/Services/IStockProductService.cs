using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IStockProductService
    {
        Task<StockProductGroupVm> FindGroupByProductId(int? id, int productId);
        Task<List<StockProductDetailsVm>> GetAllStockByProductId(int? id);
        Task<StockProductDetailsVm> FindStockProductVmById(int? id);
        Task<StockProductDetailsVm> DeleteStockProduct(int? id);
        Task<StockProductDetailsVm> AddNewProduct(int pantryId, int knownProductId);
        Task<PantryVm> GetPantryOverview(int? pantryId);
        Task EditStockProduct(StockProductDetailsVm stockProductToEdit);
        Task<bool> CheckIfPantryExists(int? id);
    }
}
