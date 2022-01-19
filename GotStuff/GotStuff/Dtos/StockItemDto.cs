using System.ComponentModel;

namespace GotStuff.Dtos
{
    public class StockItemDto
    {
        [DisplayName("#")]
        public int ItemId { get; set; }

        [DisplayName("Item")]
        public ItemDto ItemDto { get; set; }
    }
}
