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

        public async Task<List<AppUserVm>> GetAllUsersVmThatShareThePantry(int? pantryId)
        {
            List<AppUserVm> appUsersVm = new List<AppUserVm>();

            ICollection<AppUser> appUsers = await FindUsersThatShareThePantry(pantryId);

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


        private async Task<ICollection<AppUser>> FindUsersThatShareThePantry(int? pantryId)
        {
            Pantry pantry = await dbContext.Pantry.Where(p => p.Id == pantryId).FirstOrDefaultAsync();
            ICollection<AppUser> appUsers = await dbContext.Users.Where(u => u.Pantries.Contains(pantry)).ToListAsync();

            return appUsers;
        }


        public async Task RemoveTheUserFromPantry(string userId)
        {
            AppUser user = await GetUserById(userId);
            dbContext.Pantry.Where(p => p.AppUsers.Remove(user));
            await dbContext.SaveChangesAsync();
        }


        private async Task<AppUser> GetUserById(string userId)
        {
            AppUser user = await dbContext.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            return user;
        }
    }
}
