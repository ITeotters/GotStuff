using GotStuff.Data;
using GotStuff.Dtos;
using GotStuff.Models;

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
            List<Item> items = service.Item.ToList();
            List<ItemDto> dtos = new List<ItemDto>();
            
            foreach(Item item in items)
            {
                ItemDto dto = new ItemDto();
                dto.Id = item.Id;
                dto.Name = item.Name;
                dtos.Add(dto);
            }

            return dtos;
        }


        public void AddItem(ItemDto dto)
        {
            Item item = new Item();
            item.Id = dto.Id;
            item.Name = dto.Name;

            service.Add(item);
            service.SaveChanges();
        }

    }
}
