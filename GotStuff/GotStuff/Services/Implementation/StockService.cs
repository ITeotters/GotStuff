using GotStuff.Data;

namespace GotStuff.Services.Implementation
{
    public class StockService : IStockService
    {
        private readonly ApplicationDbContext context;

        public StockService(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
