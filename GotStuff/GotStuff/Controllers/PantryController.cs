using GotStuff.Models;
using GotStuff.Services;
using GotStuff.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class PantryController : Controller
    {
        private readonly IPantryService pantryService;
        private readonly UserManager<AppUser> userManager;

        public PantryController(IPantryService pantryService, UserManager<AppUser> userManager)
        {
            this.pantryService = pantryService;
            this.userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            string userId = userManager.GetUserId(User);
            List<PantryVm> pantriesVm = await pantryService.GetAllUserPantries(userId);
            return View(pantriesVm);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "Name")] PantryVm pantryVm)
        {
            string userId = userManager.GetUserId(User);
            
            await pantryService.AddNewPantry(pantryVm, userId);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {

            await pantryService.DeletePantry(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(PantryVm pantryVmToEdit)
        {
            await pantryService.EditPantryName(pantryVmToEdit);
            return RedirectToAction(nameof(Index));
        }
    }
}
