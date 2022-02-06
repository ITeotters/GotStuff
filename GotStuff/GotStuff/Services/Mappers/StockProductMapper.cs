using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services.Mappers
{
    public class StockProductMapper
    {

        public StockProductGroupVm ToVm(StockProduct model)
        {
            StockProductGroupVm retVal = new StockProductGroupVm();

            retVal.ProductId = model.KnownProductId;
            
            if(model.KnownProduct != null)
            {
                retVal.Name = model.KnownProduct.Name;
            }

            return retVal;
        }


    }
}
