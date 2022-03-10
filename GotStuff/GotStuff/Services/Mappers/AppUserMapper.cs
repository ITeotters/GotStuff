using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services.Mappers
{
    public class AppUserMapper
    {
        public AppUserVm ToVm(AppUser model)
        {
            if(model == null)
            {
                return null;
            }

            AppUserVm appUserVm = new AppUserVm();
            appUserVm.Id = model.Id;
            appUserVm.FullName = model.FullName;
            appUserVm.EmailAddress = model.Email;

            return appUserVm;
        }
    }
}
