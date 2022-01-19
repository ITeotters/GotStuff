using GotStuff.Dtos;

namespace GotStuff.Services
{
    public interface IStockService
    {
        public List<StockItemDto> GetAllStocks();
    }
}
