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


        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            StockProductGroupVm stockProductsVm = await stockProductService.FindGroupByProductId(id);
            return View(stockProductsVm); 
        }


        public async Task<IActionResult> Edit([Bind ("Name", "AquiredDate", "ExpirationDate")] StockProductDetailsVm stockVm, int? id)
        {
            stockVm = await stockProductService.FindStockProductVmById(id);
            return View(stockVm);
        }


        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditConfirmed([Bind ("Name", "ProductId", "StockProductDetailsId", "AcquiredDate", "ExpirationDate")] StockProductDetailsVm stockVm)
        {
            await stockProductService.EditStockProduct(stockVm);
            return RedirectToAction(nameof(Index), new { id = stockVm.ProductId });
        }


        public async Task<IActionResult> Create(int id)
        {
            await stockProductService.AddNewProduct(id);

            // TODO: this does not work
            return RedirectToAction(nameof(Index), new { id = id});
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

            return RedirectToAction(nameof(Index), new { id = deletedStockProduct.ProductId });
        }
    }
}
 