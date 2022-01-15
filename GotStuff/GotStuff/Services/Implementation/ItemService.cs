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
                dto.Description = item.Description;
                dto.AcquiredDate = item.AcquiredDate;
                dto.ExpirationDate = item.ExpirationDate;
                dtos.Add(dto);
            }

            return dtos;
        }


        public void AddItem(ItemDto dto)
        {
            Item item = new Item();
            item.Id = dto.Id;
            item.Name = dto.Name;
            item.Description = dto.Description;
            item.AcquiredDate = dto.AcquiredDate;
            item.ExpirationDate = dto.ExpirationDate;

            service.Add(item);
            service.SaveChanges();
        }

    }
}
