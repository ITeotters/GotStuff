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
            List<StockProductGroupVm> stockProductsVm = await stockProductService.GetOverviewOfStock();
            return View(stockProductsVm);
        }
    }
}
