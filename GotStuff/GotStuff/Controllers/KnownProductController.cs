using GotStuff.ViewModels;
using GotStuff.Services;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class KnownProductController: Controller
    {
        private readonly IKnownProductsService knownProductsService;

        public KnownProductController(IKnownProductsService knownProductsService)
        {
            this.knownProductsService = knownProductsService;
        }

        public IActionResult Index()
        {
            List<KnownProductsListVm> knownProducts = knownProductsService.GetAllKnownProducts();
            return View(knownProducts);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("Id", "Name, DefaultShelfLife")] KnownProductsListVm knownProductsVm)
        {
            if (ModelState.IsValid)
            {
                //knownProductsService.AddItem(knownProductsVm);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
