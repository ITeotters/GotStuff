using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface ISharePantryService
    {
        Task<List<AppUserVm>> GetAllUsersVmThatShareThePantry(int? pantryId);
        Task RemoveTheUserFromPantry(string userId);
    }
}
