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


        public async Task<List<DetailedStockProductVm>> GetAllTheSameStocks(int? id)
        {
            List<DetailedStockProductVm> detailedVmList = new List<DetailedStockProductVm>();


            // This works but don t know why
            var existingNameProduct = await dbContext.StockProduct
                .Where(product => product.KnownProductId == id)
                .Select(group => new DetailedStockProductVm
                {
                    Name = group.KnownProduct.Name,
                    Id = group.KnownProductId,
                    ExpirationDate = DateTime.UtcNow,
                    AcquiredDate = DateTime.UtcNow
                })
                .ToListAsync();






            //foreach (var product in existingNameProduct)
            //{
            //    DetailedStockProductVm vmProduct = new DetailedStockProductVm();
            //    vmProduct.Id = product.KnownProductId;
            //    vmProduct.Name = product.KnownProduct.Name;

            //    detailedVmList.Add(vmProduct);
            //}

            return detailedVmList;
        }
    }
}
