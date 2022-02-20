using GotStuff.Data;
using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services.Implementation
{
    public class SharePantryService :ISharePantryService
    {
        private readonly ApplicationDbContext dbContext;

        public SharePantryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<AppUserVm> GetAllUsersVmThatShareThePantry(int? pantryId)
        {
            List<AppUserVm> appUsersVm = new List<AppUserVm>();

            ICollection<AppUser> appUsers = FindUsersThatShareThePantry(pantryId);

            foreach (var user in appUsers)
            {
                AppUserVm userVm = new AppUserVm();
                userVm.Id = user.Id;
                userVm.FullName = user.FullName;
                userVm.EmailAddress = user.Email;

                appUsersVm.Add(userVm);
            }

            return appUsersVm;
        }


        private ICollection<AppUser> FindUsersThatShareThePantry(int? pantryId)
        {
            Pantry pantry = dbContext.Pantry.Where(p => p.Id == pantryId).FirstOrDefault();
            ICollection<AppUser> appUsers = dbContext.Users.Where(u => u.Pantries.Contains(pantry)).ToList();

            return appUsers;
        }
    }
}
