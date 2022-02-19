using GotStuff.Services;
using GotStuff.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class StockProductDetailsController : Controller
    {
        private readonly IStockProductService stockProductService;

        public StockProductDetailsController(IStockProductService stockProductService)
        {
            this.stockProductService = stockProductService; 
        }


        public async Task<IActionResult> Index(int? id, int knownProductId)
        {
            if(id == null)
            {
                return NotFound();
            }

            StockProductGroupVm stockProductsVm = await stockProductService.FindGroupByProductId(id, knownProductId);
            return View(stockProductsVm); 
        }


        public async Task<IActionResult> Edit([Bind ("Name", "AquiredDate", "ExpirationDate")] StockProductDetailsVm stockVm, int? id)
        {
            stockVm = await stockProductService.FindStockProductVmById(id);
            return View(stockVm);
        }


        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditConfirmed([Bind ("Name", "ProductId", "StockProductDetailsId", "AcquiredDate", "ExpirationDate", "PantryId")] StockProductDetailsVm stockVm)
        {
            await stockProductService.EditStockProduct(stockVm);
            return RedirectToAction(nameof(Index), new { id = stockVm.PantryId, knownProductId = stockVm.ProductId });
        }


        public async Task<IActionResult> Create(int id, int knownProductId)
        {
            await stockProductService.AddNewProduct(id, knownProductId);

            return RedirectToAction(nameof(Index), new { id = id, knownProductId = knownProductId });
        }

              
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var stockProductVm = await stockProductService.FindStockProductVmById(id);

            return View(stockProductVm);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            StockProductDetailsVm deletedStockProduct = await stockProductService.DeleteStockProduct(id);

            return RedirectToAction(nameof(Index), new { id = deletedStockProduct.PantryId, knownProductId = deletedStockProduct.ProductId });
        }
    }
}
 