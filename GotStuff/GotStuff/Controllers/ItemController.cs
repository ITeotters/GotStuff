using GotStuff.Dtos;
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
            List<ItemDto> items = itemService.GetAllItems();
            return View(items);
        }

        [HttpPost]
        public IActionResult Create([Bind("Id", "Name")] ItemDto dto)
        {
            if (ModelState.IsValid)
            {
                itemService.AddItem(dto);
                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }
    }
}
