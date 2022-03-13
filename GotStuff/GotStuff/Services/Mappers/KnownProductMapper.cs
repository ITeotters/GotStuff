using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services.Mappers
{
    public class KnownProductMapper
    {
        public KnownProductVm ToVm(KnownProduct model)
        {
            if (model == null)
            {
                return null;
            }

            KnownProductVm productVm = new KnownProductVm();
            productVm.KnownProductId = model.Id;
            productVm.Name = model.Name;
            productVm.DefaultShelfLife = model.DefaultShelfLife;

            return productVm;
        }


        public KnownProduct FromVm(KnownProductVm model)
        {
            if(model == null)
            {
                return null;
            }

            KnownProduct knownProduct = new KnownProduct();
            knownProduct.Id = model.KnownProductId;
            knownProduct.Name = model.Name;
            knownProduct.DefaultShelfLife = model.DefaultShelfLife;

            return knownProduct;
        }
    }
}
