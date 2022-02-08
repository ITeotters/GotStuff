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


        public async Task<IActionResult> Index()
        {
            List<StockProductGroupVm> stockProductsVm = await stockProductService.GetStockOverviewIncludingZeroCount();

            return View(stockProductsVm);
        }


        public async Task<IActionResult> Create(int id)
        {
            await stockProductService.AddNewProduct(id);

            return RedirectToAction(nameof(Index), new { id = id });
        }



    }
}
