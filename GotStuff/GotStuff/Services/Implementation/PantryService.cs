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


        public async Task<List<PantryVm>> GetAllPantries()
        {
            List<Pantry> pantries = await dbContext.Pantry.ToListAsync();
            List<PantryVm> pantriesVm = new List<PantryVm>();   

            foreach(var pantry in pantries)
            {
                PantryVm pantryVm = new PantryVm();
                pantryVm.Id = pantry.Id;
                pantryVm.Name = pantry.Name;

                pantriesVm.Add(pantryVm);
            }

            return pantriesVm;
        } 


        public async Task AddNewPantry(PantryVm pantryVm)
        {
            Pantry pantry = new Pantry();

            pantry.Id = pantryVm.Id;
            pantry.Name = pantryVm.Name;
            dbContext.Add(pantry);
            await dbContext.SaveChangesAsync();
        }
    }
}
