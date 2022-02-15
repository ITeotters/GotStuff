using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IPantryService
    {
        Task<List<PantryVm>> GetAllPantries();
        Task AddNewPantry(PantryVm pantryVm);
        Task DeletePantry(int? id);
        Task EditPantryName(PantryVm pantryVmToEdit);
    }
}
