using System.ComponentModel;

namespace GotStuff.Dtos
{
    public class StockItemDto
    {
        public int ItemId { get; set; }

        [DisplayName("Item")]
        public string ItemName { get; set; }

        public int Count { get; set; }


        public StockItemDto()
        {

        }


        public StockItemDto(string name, int count)
        {
            this.ItemName = name;
            this.Count = count;
        }
    }
}
