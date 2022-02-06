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


        public async Task<List<StockProductGroupVm>> GetOverviewOfStock()
        {
            var stockProducts = await dbContext.StockProduct
                .GroupBy(stock => stock.KnownProductId)
                .Select(group => new StockProductGroupVm
                {
                    Name = group.FirstOrDefault().KnownProduct.Name,
                    ProductId = group.Key,
                    Count = group.Count()
                })
                .ToListAsync();

            return stockProducts;
        }


        public async Task<List<DetailedStockProductVm>> GetAllStockByProductId(int? id)
        {
            var stockListQuery = dbContext.StockProduct
                .Where(product => product.KnownProductId == id)
                .Select(stockItem => new DetailedStockProductVm
                {
                    Name = stockItem.KnownProduct.Name,
                    DetailedStockProductId = stockItem.Id,
                    ProductId = stockItem.KnownProductId,
                    ExpirationDate = stockItem.ExpirationDate,
                    AcquiredDate = stockItem.AcquiredDate
                });

            var stockList = await stockListQuery.ToListAsync();

            return stockList;
        }


        public async Task<DetailedStockProductVm> FindStockProductById(int? id)
        {
            var stockProduct = await dbContext.StockProduct.Include(sp => sp.KnownProduct).FirstOrDefaultAsync(sp => sp.Id == id);

            DetailedStockProductVm stockProductVm = TurnStockProductToDetailedStockProductVm(stockProduct);

            return stockProductVm;
        }


        public async Task<DetailedStockProductVm> DeleteStockProduct(int? id)
        {
            var stockProductToDelete = await dbContext.StockProduct.Include(sp => sp.KnownProduct).FirstOrDefaultAsync(sp => sp.Id == id);

            dbContext.Remove(stockProductToDelete);
            await dbContext.SaveChangesAsync();

            DetailedStockProductVm stockProductVm = TurnStockProductToDetailedStockProductVm(stockProductToDelete);

            return stockProductVm;

        }


        private DetailedStockProductVm TurnStockProductToDetailedStockProductVm(StockProduct stockProduct)
        {
            DetailedStockProductVm stockProductVm = new DetailedStockProductVm();
            stockProductVm.DetailedStockProductId = stockProduct.Id;
            stockProductVm.ProductId = stockProduct.KnownProductId;
            stockProductVm.Name = stockProduct.KnownProduct.Name;
            stockProductVm.AcquiredDate = stockProduct.AcquiredDate;
            stockProductVm.ExpirationDate = stockProduct.ExpirationDate;

            return stockProductVm;
        }


        public async Task AddNewProduct(int knownProductId)
        {
            StockProduct stockProduct = new StockProduct();
            KnownProduct knownProduct = await dbContext.KnownProduct.Where(kp => kp.Id == knownProductId).FirstOrDefaultAsync();
            TimeSpan shelfLife = TimeSpan.FromDays(knownProduct.DefaultShelfLife);

            stockProduct.KnownProductId = knownProductId;
            stockProduct.AcquiredDate = DateTime.Now;
            stockProduct.ExpirationDate = stockProduct.AcquiredDate + shelfLife;
            
            dbContext.StockProduct.Add(stockProduct);
            await dbContext.SaveChangesAsync();
        }


        public async Task<StockProductGroupVm> FindGroupByProductId(int? id)
        {
            StockProductGroupVm retVal = new StockProductGroupVm();

            var knownproduct = await dbContext.KnownProduct.Where(np => np.Id == id).FirstOrDefaultAsync();

            retVal.Name = knownproduct.Name;
            retVal.ProductId = id.Value;
            retVal.StockProducts = await GetAllStockByProductId(id);
            retVal.Count = retVal.StockProducts.Count;

            return retVal;
        }
    }
}
