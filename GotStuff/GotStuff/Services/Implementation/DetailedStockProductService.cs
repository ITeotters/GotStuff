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


        public async Task<List<DetailedStockProductVm>> GetAllTheSameStocks(DetailedStockProductVm detailedProductVm)
        {
            List<DetailedStockProductVm> detailedVmList = new List<DetailedStockProductVm>();

            var existingNameProduct = await dbContext.KnownProduct
                .Where(product => product.Name == detailedProductVm.Name)
                .ToListAsync();

            foreach(var product in existingNameProduct)
            {
                DetailedStockProductVm vmProduct = new DetailedStockProductVm();
                vmProduct.Id = product.Id;
                vmProduct.Name = product.Name;

                detailedVmList.Add(vmProduct);
            }

            return detailedVmList;
        }
    }
}
