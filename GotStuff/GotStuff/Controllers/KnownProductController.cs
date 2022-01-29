using GotStuff.ViewModels;
using GotStuff.Services;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class KnownProductController: Controller
    {
        private readonly IKnownProductsService knownProductsService;

        public KnownProductController(IKnownProductsService knownProductsService)
        {
            this.knownProductsService = knownProductsService;
        }

        public IActionResult Index()
        {
            List<KnownProductsListVm> knownProducts = knownProductsService.GetAllKnownProducts();
            return View(knownProducts);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("Id", "Name, DefaultShelfLife")] KnownProductsListVm knownProductsVm)
        {
            if (ModelState.IsValid)
            {
                knownProductsService.AddNewProduct(knownProductsVm);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KnownProductsListVm knownProduct = await knownProductsService.GetProductById(id);

            if (knownProduct == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int? id)
        //{
        //    var riddle = await context.Riddle.FindAsync(id);
        //    context.Riddle.Remove(riddle);
        //    await context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));

    }
}
