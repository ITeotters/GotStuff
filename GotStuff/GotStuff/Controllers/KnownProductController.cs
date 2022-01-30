using GotStuff.ViewModels;
using GotStuff.Services;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class KnownProductController : Controller
    {
        private readonly IKnownProductService knownProductsService;

        public KnownProductController(IKnownProductService knownProductsService)
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


        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            KnownProductVm product = await knownProductsService.GetProductVmById(id);

            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        public async Task<IActionResult> Edit([Bind("Id", "Name", "DefaultShelfLife")] KnownProductVm product, int? id)
        {
            product = await knownProductsService.GetProductVmById(id);
            return View(product);
        }


        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditSave([Bind("Id", "Name", "DefaultShelfLife")] KnownProductVm product)
        {
            await knownProductsService.EditProduct(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
