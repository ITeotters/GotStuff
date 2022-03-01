using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface ISharePantryService
    {
        Task<PantryVm> GetPantryVm(int? pantryId);
        Task RemoveTheUserFromPantry(string userId, int pantryId);
        Task AddNewUserToPantry(AppUserVm user, int pantryId);
    }
}
