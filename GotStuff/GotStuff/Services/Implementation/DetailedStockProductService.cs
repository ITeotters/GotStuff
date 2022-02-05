using GotStuff.Data;
using GotStuff.Models;
using GotStuff.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GotStuff.Services.Implementation
{
    public class DetailedStockProductService : IDetailedStockProductService
    {
        private readonly ApplicationDbContext dbContext;

        public DetailedStockProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<DetailedStockProductVm>> GetAllStockByProductId(int? id)
        {
            var stockListQuery = dbContext.StockProduct
                .Where(product => product.KnownProductId == id)
                .Select(stockItem => new DetailedStockProductVm
                {
                    Name = stockItem.KnownProduct.Name,
                    Id = stockItem.Id,
                    ProductId = stockItem.KnownProductId,
                    ExpirationDate = DateTime.UtcNow,
                    AcquiredDate = DateTime.UtcNow
                });

            var stockList = await stockListQuery.ToListAsync();

            return stockList;
        }


        public async Task<DetailedStockProductVm> FindStockProductById(int? id)
        {
            var stockProduct = await dbContext.StockProduct.Include(sp => sp.KnownProduct).FirstOrDefaultAsync(sp => sp.Id == id);

            DetailedStockProductVm stockProductVm = new DetailedStockProductVm();
            stockProductVm.Id = stockProduct.Id;
            stockProductVm.ProductId = stockProduct.KnownProductId;
            stockProductVm.Name = stockProduct.KnownProduct.Name;
            stockProductVm.AcquiredDate = stockProduct.AcquiredDate;
            stockProductVm.ExpirationDate = stockProduct.ExpirationDate;

            return stockProductVm;
        }
    }
}
