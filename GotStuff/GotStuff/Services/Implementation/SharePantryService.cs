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
            Pantry pantry = await dbContext.Pantry.Where(p => p.Id == pantryId).Include(p => p.AppUsers).FirstOrDefaultAsync();
            ICollection<AppUser> appUsers = pantry.AppUsers;


            return appUsers;
        }


        public async Task RemoveTheUserFromPantry(string userId, int pantryId)
        {
            var pantry = await dbContext.Pantry.Where(p => p.Id == pantryId).FirstOrDefaultAsync();

            await dbContext.SaveChangesAsync();
        }


        private async Task<AppUser> GetUserById(string userId)
        {
            AppUser user = await dbContext.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            return user;
        }
    }
}
