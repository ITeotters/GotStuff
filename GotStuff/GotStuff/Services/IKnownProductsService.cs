using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IKnownProductsService
    {
        List<KnownProductsListVm> GetAllKnownProducts();
        void AddNewProduct(KnownProductsListVm knownProductsVm);
        void RemoveProduct(KnownProductsListVm productToRemove);
        Task<KnownProductsListVm> GetProductById(int? id);
    }
}
