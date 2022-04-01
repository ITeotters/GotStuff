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

        public async Task<IActionResult> Index()
        {
            List<KnownProductVm> knownProducts = await knownProductsService.GetAllKnownProducts();
            return View(knownProducts);
        }


        [HttpPost]
        public async Task<IActionResult> Index(string searchedTerm)
        {
            List<KnownProductVm> result = new List<KnownProductVm>();

            if (string.IsNullOrEmpty(searchedTerm))
            {
                result = await knownProductsService.GetAllKnownProducts();
                return View(nameof(Index), result);
            }

            result = await knownProductsService.GetAllSearchedKnownProduct(searchedTerm);

            return View(nameof(Index), result);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "Name, DefaultShelfLife")] KnownProductVm knownProductVm)
        {
            bool isProductExisting = knownProductsService.CheckIfProductExists(knownProductVm);

            if (ModelState.IsValid && !isProductExisting)
            {
                await knownProductsService.AddNewProduct(knownProductVm);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Message = "Exist";
                return View();
            }
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


        public async Task<IActionResult> Edit([Bind("KnownProductId", "Name", "DefaultShelfLife")] KnownProductVm product, int? id)
        {
            product = await knownProductsService.GetProductVmById(id);
            return View(product);
        }


        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditSave([Bind("KnownProductId", "Name", "DefaultShelfLife")] KnownProductVm product)
        {
            bool isProductExisting = knownProductsService.CheckIfProductExists(product);

            if (ModelState.IsValid && !isProductExisting)
            {
                await knownProductsService.EditProduct(product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Message = "Exist";
                return View();
            }
        }
    }
}
