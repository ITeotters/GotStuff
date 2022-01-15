using GotStuff.Services;
using Microsoft.AspNetCore.Mvc;

namespace GotStuff.Controllers
{
    public class ItemController: Controller
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public IActionResult Index()
        {
            var items = itemService.GetAllItems();
            return View(items);
        }
    }
}
