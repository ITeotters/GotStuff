using GotStuff.Dtos;
using GotStuff.Services;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService service;

        public StockController(IStockService service)
        {
            this.service = service;
        }


        public IActionResult Index()
        {
            var dtos = service.GetAllStocks();
            return View(dtos);
        }
    }
}
