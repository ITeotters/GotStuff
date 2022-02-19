using GotStuff.Data;
using GotStuff.Models;
using GotStuff.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GotStuff.Services.Implementation
{
    public class PantryService : IPantryService
    {
        private readonly ApplicationDbContext dbContext;

        public PantryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<PantryVm>> GetAllUserPantries(string userId)
        {
            List<PantryVm> pantriesVm = new List<PantryVm>();

            AppUser owner = await GetUserById(userId);
            List<Pantry> pantries = await dbContext.Pantry.Where(p => p.AppUsers.Contains(owner)).ToListAsync();

            foreach (var pantry in pantries)
            {
                PantryVm pantryVm = new PantryVm();
                pantryVm.Id = pantry.Id;
                pantryVm.Name = pantry.Name;

                pantriesVm.Add(pantryVm);
            }

            return pantriesVm;
        } 


        public async Task AddNewPantry(PantryVm pantryVm, string userId)
        {
            Pantry pantry = new Pantry();

            AppUser owner = await GetUserById(userId);

            pantry.Id = pantryVm.Id;
            pantry.Name = pantryVm.Name;

            pantry.AppUsers.Add(owner);
            dbContext.Pantry.Add(pantry);
            await dbContext.SaveChangesAsync();
        }


        private async Task<AppUser> GetUserById(string id)
        {
            AppUser user = await dbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            return user;
        }


        public async Task DeletePantry(int? id)
        {
            var pantryToDelete = await dbContext.Pantry.FirstOrDefaultAsync(sp => sp.Id == id);

            dbContext.Remove(pantryToDelete);
            await dbContext.SaveChangesAsync();
        }


        public async Task EditPantryName(PantryVm pantryVmToEdit)
        {
            var pantryToEdit = await dbContext.Pantry.FirstOrDefaultAsync(sp => sp.Id == pantryVmToEdit.Id);
            pantryToEdit.Id = pantryVmToEdit.Id;
            pantryToEdit.Name = pantryVmToEdit.Name;
            await dbContext.SaveChangesAsync();
        }
    }
}
