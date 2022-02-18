using GotStuff.Data;
using GotStuff.Services;
using GotStuff.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class StockProductController : Controller
    {
        private readonly IStockProductService stockProductService;

        public StockProductController(IStockProductService stockProductService)
        {
            this.stockProductService = stockProductService;
        }


        public async Task<IActionResult> PantryStock (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool isPantryExisting = await stockProductService.CheckIfPantryExists(id);

            if (isPantryExisting)
            {
                PantryVm pantryContentsVm = await stockProductService.GetPantryOverview(id);
                return View(pantryContentsVm);
            }
            else
            {
                return NotFound();
            }
        }


        public async Task<IActionResult> Create(int id, int knownProductId)
        {
            StockProductDetailsVm stockDetailsVm = await stockProductService.AddNewProduct(id, knownProductId);

            return RedirectToAction(nameof(PantryStock), new { id = stockDetailsVm.PantryId});
        }
    }
}
