using GotStuff.Data;
using GotStuff.Dtos;
using GotStuff.Models;

namespace GotStuff.Services.Implementation
{
    public class StockService : IStockService
    {
        private readonly ApplicationDbContext context;

        public StockService(ApplicationDbContext context)
        {
            this.context = context;
        }


        public List<StockItemDto> GetAllStocks()
        {
            List<StockItem> stocks = context.StockItem.ToList();
            List<StockItemDto> dtos = new List<StockItemDto>();

            // insert Linq here??

            return dtos;
        }
    }
}
