using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IPantryService
    {
        Task<List<PantryVm>> GetAllPantries();
        Task AddNewPantry(PantryVm pantryVm);
    }
}
