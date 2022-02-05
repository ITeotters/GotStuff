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


        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            List<DetailedStockProductVm> detailedProducts = await detailedProductService.GetAllStockByProductId(id);
            return View(detailedProducts);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "Name", "ExpirationDate", "AquiredDate")] DetailedStockProductVm stockProductVm)
        {




            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var stockProductVm = await detailedProductService.FindStockProductById(id);

            return View(stockProductVm);
        }
    }
}
