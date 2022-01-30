using GotStuff.Data;
using GotStuff.ViewModels;
using GotStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace GotStuff.Services.Implementation
{
    public class StockProductService : IStockProductService
    {
        private readonly ApplicationDbContext dbContext;

        public StockProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<StockProductVm>> GetOverviewOfStock()
        {           
            var stockProducts = await dbContext.StockProduct
                .GroupBy(stock => stock.KnownProductId)
                .Select(group => new StockProductVm
                {
                    Name = group.FirstOrDefault().KnownProduct.Name,
                    ProductId = group.Key,
                    Count = group.Count()
                })
                .ToListAsync();

            return stockProducts;
        }
    }
}
