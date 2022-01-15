using GotStuff.Data;
using GotStuff.Dtos;

namespace GotStuff.Services.Implementation
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext service;

        public ItemService(ApplicationDbContext dbService)
        {
            this.service = dbService;
        }

        public List<ItemDto> GetAllItems()
        {
            List<ItemDto> items = new List<ItemDto>();
            return items;
        }
    }
}
