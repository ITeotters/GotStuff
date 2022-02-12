using GotStuff.Services;
using GotStuff.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class PantryController : Controller
    {
        private readonly IPantryService pantryService;

        public PantryController(IPantryService pantryService)
        {
            this.pantryService = pantryService;
        }


        public async Task<IActionResult> Index()
        {
            List<PantryVm> pantriesVm = await pantryService.GetAllPantries();
            return View(pantriesVm);
        }
    }
}
