using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services.Mappers
{
    public class StockProductMapper
    {
        public StockProductDetailsVm ToVm(StockProduct model)
        {
            if (model == null)
            {
                return null;
            }

            StockProductDetailsVm stockProductVm = new StockProductDetailsVm();
            stockProductVm.StockProductDetailsId = model.Id;
            stockProductVm.ProductId = model.KnownProductId;
            stockProductVm.AcquiredDate = model.AcquiredDate;
            stockProductVm.ExpirationDate = model.ExpirationDate;
            stockProductVm.PantryId = model.PantryId;

            if(model.KnownProduct != null)
            {
                stockProductVm.Name = model.KnownProduct.Name;
            }

            return stockProductVm;
        }
    }
}
