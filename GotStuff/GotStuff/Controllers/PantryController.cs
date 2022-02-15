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


        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "Name")] PantryVm pantryVm)
        {
            await pantryService.AddNewPantry(pantryVm);
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
