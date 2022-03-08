using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services.Mappers
{
    public class PantryMapper
    {
        public PantryVm ToVm(Pantry model)
        {
            PantryVm pantryVm = new PantryVm();
            pantryVm.Id = model.Id;
            pantryVm.Name = model.Name;

            if(model.AppUsers != null)
            {
                CopyPantryUsersToVm(model, pantryVm);
            }

            return pantryVm;
        }

        private void CopyPantryUsersToVm(Pantry model, PantryVm pantryVm)
        {
            AppUserMapper mapper = new AppUserMapper();
            pantryVm.AppUsers = new List<AppUserVm>();

            foreach(AppUser user in model.AppUsers)
            {
                AppUserVm appUserVm = mapper.ToVm(user);
                pantryVm.AppUsers.Add(appUserVm);
            }
        }
    }
}
