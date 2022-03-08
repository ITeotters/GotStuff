using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface ISharePantryService
    {
        Task<PantryVm> GetPantryVm(int? pantryId);
        Task RemoveTheUserFromPantry(string userId, int pantryId);
        Task AddNewUserToPantry(SharePantryVm sharePantry);
        Task<bool> IsUserPantryMember(string userEmail, int pantryId);
        Task<bool> CheckIfUserExistsInDatabase(string userEmail);
        Task<SharePantryVm> GetSharedPantryByPantryId(int pantryId);
    }
}
