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


        public IActionResult SharePantry(int id)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SharePantry([Bind("Id", "FullName, EmailAddress", "PantryId")] AppUserVm user, int pantryId)
        {

            // check if user is already in the list
            bool isUserExisting = false;

            if (ModelState.IsValid && !isUserExisting)
            {
                await sharePantryService.AddNewUserToPantry(user, pantryId);
                return RedirectToAction(nameof(Index), new {id = pantryId});
            }
            else
            {
                ViewBag.Message = "UserExist";
                return View();
            }


            return RedirectToAction(nameof(Index), new { id = pantryId });
        }
    }
}
