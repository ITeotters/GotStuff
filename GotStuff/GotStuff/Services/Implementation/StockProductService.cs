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


        public async Task<PantryVm> GetPantryOverview(int? pantryId)
        {
            PantryVm retVal = new PantryVm();
            retVal.Contents = new List<StockProductGroupVm>();
            var knownProducts = await dbContext.KnownProduct.ToListAsync();

            foreach(KnownProduct product in knownProducts)
            {
                StockProductGroupVm stockGroupVm = new StockProductGroupVm();
                stockGroupVm.Name = product.Name;
                stockGroupVm.ProductId = product.Id;
                stockGroupVm.Count = await GetStockCountForProductInPantry(product.Id, pantryId);
                stockGroupVm.PantryId = (int)pantryId;

                retVal.Contents.Add(stockGroupVm);
            }

            return retVal;
        }


        public async Task<bool> CheckIfPantryExists(int? id)
        {
            var pantries = await dbContext.Pantry.Where(p => p.Id == id).FirstOrDefaultAsync();
            bool doesPantryExist = pantries != null;
            return doesPantryExist;
        }


        private async Task<int> GetStockCountForProductInPantry(int productId, int? pantryId)
        {
            var retVal = await dbContext.StockProduct
                .Where(sp => sp.KnownProductId == productId && sp.PantryId == pantryId)
                .CountAsync();

            return retVal;
        }


        public async Task<List<StockProductDetailsVm>> GetAllStockByProductId(int? id)
        {
            var stockListQuery = dbContext.StockProduct
                .Where(product => product.KnownProductId == id)
                .Select(stockItem => new StockProductDetailsVm
                {
                    Name = stockItem.KnownProduct.Name,
                    StockProductDetailsId = stockItem.Id,
                    ProductId = stockItem.KnownProductId,
                    ExpirationDate = stockItem.ExpirationDate,
                    AcquiredDate = stockItem.AcquiredDate
                });

            var stockList = await stockListQuery.ToListAsync();

            return stockList;
        }


        public async Task<StockProductDetailsVm> FindStockProductVmById(int? id)
        {
            var stockProduct = await dbContext.StockProduct.Include(sp => sp.KnownProduct).FirstOrDefaultAsync(sp => sp.Id == id);

            StockProductDetailsVm stockProductVm = ToVm(stockProduct);

            return stockProductVm;
        }


        public async Task<StockProductDetailsVm> DeleteStockProduct(int? id)
        {
            var stockProductToDelete = await dbContext.StockProduct.Include(sp => sp.KnownProduct).FirstOrDefaultAsync(sp => sp.Id == id);

            dbContext.Remove(stockProductToDelete);
            await dbContext.SaveChangesAsync();

            StockProductDetailsVm stockProductVm = ToVm(stockProductToDelete);

            return stockProductVm;

        }


        private StockProductDetailsVm ToVm(StockProduct stockProduct)
        {
            StockProductDetailsVm stockProductVm = new StockProductDetailsVm();
            stockProductVm.StockProductDetailsId = stockProduct.Id;
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
            stockProduct.PantryId = 1;
            
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


        private async Task<StockProduct> GetStockProductById(int id)
        {
            StockProduct retVal = await dbContext.StockProduct
                .Where(sp => sp.KnownProductId == id)
                .FirstOrDefaultAsync();

            return retVal; 
        }


        public async Task EditStockProduct(StockProductDetailsVm stockProductVmToEdit)
        {
            StockProduct stockProduct = await GetStockProductById(stockProductVmToEdit.ProductId);
            stockProduct.KnownProductId = stockProductVmToEdit.ProductId;
            stockProduct.AcquiredDate = stockProductVmToEdit.AcquiredDate;
            stockProduct.ExpirationDate = stockProductVmToEdit.ExpirationDate;

            await dbContext.SaveChangesAsync();
        }
    }
}
