using GotStuff.Data;
using GotStuff.Models;
using GotStuff.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GotStuff.Services.Implementation
{
    public class SharePantryService :ISharePantryService
    {
        private readonly ApplicationDbContext dbContext;

        public SharePantryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private async Task<List<AppUserVm>> GetAllUsersVmThatShareThePantry(int? pantryId)
        {
            List<AppUserVm> appUsersVm = new List<AppUserVm>();

            ICollection<AppUser> appUsers = await FindUsersForPantry(pantryId);

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


        public async Task<PantryVm> GetPantryVm(int? pantryId)
        {
            PantryVm pantryVm = new PantryVm();
            pantryVm.AppUsers = await GetAllUsersVmThatShareThePantry(pantryId);
            pantryVm.Id = pantryId.Value;

            return pantryVm;
        }


        private async Task<ICollection<AppUser>> FindUsersForPantry(int? pantryId)
        {
            Pantry pantry = await GetPantryById(pantryId);
            ICollection<AppUser> appUsers = pantry.AppUsers;


            return appUsers;
        }


        public async Task RemoveTheUserFromPantry(string userId, int pantryId)
        {
            var pantry = await GetPantryById(pantryId);
            AppUser userToRemove = pantry.AppUsers.Where(u => u.Id == userId).FirstOrDefault();
            pantry.AppUsers.Remove(userToRemove);

            await dbContext.SaveChangesAsync();
        }


        private async Task<Pantry> GetPantryById(int? pantryId)
        {
            Pantry pantry = await dbContext.Pantry.Where(p => p.Id == pantryId).Include(p => p.AppUsers).FirstOrDefaultAsync();
            return pantry;
        }


        public async Task AddNewUserToPantry(AppUserVm user, int pantryId)
        {
            var pantry = await GetPantryById(pantryId);
            AppUser userToAdd = pantry.AppUsers.Where(u => u.Id == user.Id).FirstOrDefault();


            //Check if ok and why pantryId is 0
            userToAdd.Id = user.Id;
            userToAdd.Email = user.EmailAddress;
            userToAdd.Pantries.Add(pantry);
            pantry.AppUsers.Add(userToAdd);

            await dbContext.SaveChangesAsync();
        }
    }
}
