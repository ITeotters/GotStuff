using GotStuff.Dtos;

namespace GotStuff.Services
{
    public interface IItemService
    {
        public List<ItemDto> GetAllItems();
    }
}
