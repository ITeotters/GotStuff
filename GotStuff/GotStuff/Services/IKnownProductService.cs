using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IKnownProductService
    {
        Task<List<KnownProductVm>> GetAllKnownProducts();
        Task<List<KnownProductVm>> GetAllSearchedKnownProduct(string searchedTerm);
        Task AddNewProduct(KnownProductVm knownProductsVm);
        Task RemoveProduct(int id);
        Task<KnownProductVm> GetProductVmById(int? id);
        Task EditProduct(KnownProductVm updatedProduct);
        bool CheckIfProductExists(KnownProductVm existingProduct);
    }
}
