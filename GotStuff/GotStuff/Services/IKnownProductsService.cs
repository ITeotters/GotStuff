using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IKnownProductsService
    {
        List<KnownProductsListVm> GetAllKnownProducts();
    }
}
