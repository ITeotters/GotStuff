using GotStuff.Services;
using GotStuff.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class DetailedStockProductController : Controller
    {
        private readonly IDetailedStockProductService detailedProductService;

        public DetailedStockProductController(IDetailedStockProductService detailedProductService)
        {
            this.detailedProductService = detailedProductService; 
        }


        public async Task<IActionResult> Index(DetailedStockProductVm detailedProductVm)
        {
            List<DetailedStockProductVm> detailedProducts = await detailedProductService.GetAllTheSameStocks(detailedProductVm);
            return View(detailedProducts);
        }
    }
}
