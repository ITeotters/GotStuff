using GotStuff.ViewModels;
using GotStuff.Services;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class KnownProductController : Controller
    {
        private readonly IKnownProductsService knownProductsService;

        public KnownProductController(IKnownProductsService knownProductsService)
        {
            this.knownProductsService = knownProductsService;
        }

        public IActionResult Index()
        {
            List<KnownProductVm> knownProducts = knownProductsService.GetAllKnownProducts();
            return View(knownProducts);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("Id", "Name, DefaultShelfLife")] KnownProductVm knownProductsVm)
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

            KnownProductVm knownProduct = await knownProductsService.GetProductVmById(id);

            if (knownProduct == null)
            {
                return NotFound();
            }

            return View(knownProduct);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await knownProductsService.RemoveProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
