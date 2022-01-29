using GotStuff.Data;
using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services.Implementation
{
    public class KnownProductsService : IKnownProductsService
    {
        private readonly ApplicationDbContext service;

        public KnownProductsService(ApplicationDbContext dbService)
        {
            this.service = dbService;
        }


        public List<KnownProductsListVm> GetAllKnownProducts()
        {
            List<KnownProductsListVm> knownProductsVm = new List<KnownProductsListVm>();
            List<KnownProduct> knownProducts = service.KnownProducts.ToList();

            foreach(KnownProduct product in knownProducts)
            {
                KnownProductsListVm productsVm = new KnownProductsListVm();
                productsVm.Id = product.Id;
                productsVm.Name = product.Name;
                productsVm.DefaultShelfLife = product.DefaultShelfLife;
                knownProductsVm.Add(productsVm);
            }

            return knownProductsVm;
        }
    }
}
