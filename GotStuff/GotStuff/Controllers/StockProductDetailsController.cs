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


        public async Task<IActionResult> Create(int id)
        {
            await stockProductService.AddNewProduct(id);

            return RedirectToAction(nameof(Index), new { id = id});
        }

              
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var stockProductVm = await stockProductService.FindStockProductById(id);

            return View(stockProductVm);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            StockProductDetailsVm deletedStockProduct = await stockProductService.DeleteStockProduct(id);

            return RedirectToAction(nameof(Index), new { id = deletedStockProduct.ProductId });
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var stockProductVm = await stockProductService.FindStockProductById(id);

            if (stockProductVm == null)
            {
                return NotFound();
            }

            return View(stockProductVm);
        }
    }
}
