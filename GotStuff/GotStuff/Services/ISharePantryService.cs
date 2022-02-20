using GotStuff.ViewModels;

namespace GotStuff.Services
{
    public interface ISharePantryService
    {
        List<AppUserVm> GetAllUsersVmThatShareThePantry(int? pantryId);
    }
}
