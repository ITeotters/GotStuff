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

        public IActionResult Index(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            List<AppUserVm> appUsersVm = sharePantryService.GetAllUsersVmThatShareThePantry(id);

            return View(appUsersVm);
        }
    }
}
