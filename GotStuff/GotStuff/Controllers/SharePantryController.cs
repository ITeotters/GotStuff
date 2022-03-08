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

            PantryVm pantryVm = await sharePantryService.GetPantryVm(id);

            return View(pantryVm);
        }


        public async Task<IActionResult> Delete(string id, int pantryId)
        {
            if (id == null)
            {
                return NotFound();
            }

            string currentUserId = userManager.GetUserId(User);
            if (currentUserId == id)
            {
                ViewBag.Message = "PantryOwner";
                return RedirectToAction(nameof(Index), new { id = pantryId });
            }
            else
            {
                await sharePantryService.RemoveTheUserFromPantry(id, pantryId);
            }

            return RedirectToAction(nameof(Index), new { id = pantryId });
        }


        public async Task<IActionResult> SharePantry(int pantryId)
        {
            SharePantryVm sharePantryVm = await sharePantryService.GetSharedPantryByPantryId(pantryId);

            return View(sharePantryVm);
        }


        [HttpPost]
        public async Task<IActionResult> SharePantry([Bind("AppUser", "Pantry")] SharePantryVm sharePantry)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            bool userIsInDatabase = await sharePantryService.CheckIfUserExistsInDatabase(sharePantry.AppUser.EmailAddress);
            if (!userIsInDatabase)
            {
                ViewBag.Message = "NoUserAccount";
                return View();
            }

            bool userCanSharePantry = !await sharePantryService.IsUserPantryMember(sharePantry.AppUser.EmailAddress, sharePantry.Pantry.Id);
            if (!userCanSharePantry)
            {
                ViewBag.Message = "UserExist";
                return View();
            }

            await sharePantryService.AddNewUserToPantry(sharePantry);
            return RedirectToAction(nameof(Index), new {id = sharePantry.Pantry.Id});
        }
    }
}
