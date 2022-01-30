using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IKnownProductService
    {
        List<KnownProductVm> GetAllKnownProducts();
        Task AddNewProduct(KnownProductVm knownProductsVm);
        Task RemoveProduct(int id);
        Task<KnownProductVm> GetProductVmById(int? id);
        Task EditProduct(KnownProductVm updatedProduct);
    }
}
