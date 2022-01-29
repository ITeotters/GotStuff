using GotStuff.ViewModels;
using GotStuff.Services;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class KnownProductsController: Controller
    {
        private readonly IKnownProductsService knownProductsService;

        public KnownProductsController(IKnownProductsService knownProductsService)
        {
            this.knownProductsService = knownProductsService;
        }

        public IActionResult Index()
        {
            //List<KnownProductsListVm> items = itemService.GetAllKnownProducts();
            ModelState.Clear();
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("Id", "Name")] KnownProductsListVm itemsVm)
        {
            if (ModelState.IsValid)
            {
                //itemService.AddItem(itemsVm);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
