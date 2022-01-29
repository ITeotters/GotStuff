using GotStuff.Data;
using GotStuff.ViewModels;
using GotStuff.Models;

namespace GotStuff.Services.Implementation
{
    public class StockService : IStockService
    {
        private readonly ApplicationDbContext context;
        private List<Stock> stocks;

        public StockService(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
