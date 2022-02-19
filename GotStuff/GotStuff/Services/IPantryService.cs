using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface IPantryService
    {
        Task<List<PantryVm>> GetAllUserPantries(string userId);
        Task AddNewPantry(PantryVm pantryVm, string owner);
        Task DeletePantry(int? id);
        Task EditPantryName(PantryVm pantryVmToEdit);
    }
}
