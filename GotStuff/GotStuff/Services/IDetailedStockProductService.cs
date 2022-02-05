using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IDetailedStockProductService
    {
        Task<List<DetailedStockProductVm>> GetAllStockByProductId(int? id);
        Task<DetailedStockProductVm> FindStockProductById(int? id);
    }
}
