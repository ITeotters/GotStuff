using GotStuff.Data;
using GotStuff.Dtos;
using GotStuff.Models;

namespace GotStuff.Services.Implementation
{
    public class StockService : IStockService
    {
        private readonly ApplicationDbContext context;
        private List<StockItem> stocks;

        public StockService(ApplicationDbContext context)
        {
            this.context = context;
        }


        public List<StockItemDto> GetAllStocks()
        {
            List<StockItemDto> dtos = new List<StockItemDto>();
            stocks = ConvertItemsInStockItems();

            foreach(StockItem stock in stocks)
            {
                StockItemDto dto = new StockItemDto();
                dto.ItemId = stock.ItemId;
                dto.ItemName = stock.Item.Name;
                dtos.Add(dto);
            }

            List<StockItemDto> resultDtos = OrderByName(dtos);
           
            return resultDtos;
        }

        
        private List<StockItemDto> OrderByName(List<StockItemDto> dtos)
        {
            List<StockItemDto> resultDtos = dtos
                .OrderBy(dto => dto.ItemName)
                .ToList();

            return resultDtos;
        }


        private List<StockItem> ConvertItemsInStockItems()
        {
            List<Item> items = context.Item.ToList();
            stocks = new List<StockItem>();

            foreach (Item item in items)
            {
                StockItem stock = new StockItem();
                stock.ItemId = item.Id;
                stock.Item = item;
                stocks.Add(stock);
            }

            return stocks;
        }
    }
}
