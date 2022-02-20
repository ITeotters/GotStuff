using GotStuff.Models;
using GotStuff.Services;
using GotStuff.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class SharePantryController :Controller
    {
        private readonly ISharePantryService sharePantryService;
        private readonly UserManager<AppUser> userManager;

        public SharePantryController(ISharePantryService sharePantryService, UserManager<AppUser> userManager)
        {
            this.sharePantryService = sharePantryService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            List<AppUserVm> appUsersVm = await sharePantryService.GetAllUsersVmThatShareThePantry(id);

            return View(appUsersVm);
        }



        //TODO: need the pantryId as well I think + work on the html part
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string currentUserId = userManager.GetUserId(User);
            if (currentUserId == id)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await sharePantryService.RemoveTheUserFromPantry(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
