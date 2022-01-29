using GotStuff.Data;
using GotStuff.Models;
using GotStuff.ViewModels;

namespace GotStuff.Services.Implementation
{
    public class KnownProductsService : IKnownProductsService
    {
        private readonly ApplicationDbContext dbContext;

        public KnownProductsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<KnownProductsListVm> GetAllKnownProducts()
        {
            List<KnownProductsListVm> knownProductsVm = new List<KnownProductsListVm>();
            List<KnownProduct> knownProducts = dbContext.KnownProducts.ToList();

            foreach (KnownProduct product in knownProducts)
            {
                KnownProductsListVm productsVm = new KnownProductsListVm();
                productsVm.Id = product.Id;
                productsVm.Name = product.Name;
                productsVm.DefaultShelfLife = product.DefaultShelfLife;
                knownProductsVm.Add(productsVm);
            }

            return knownProductsVm;
        }


        public void AddNewProduct(KnownProductsListVm newProduct)
        {
            KnownProduct productToAdd = new KnownProduct();
            productToAdd.Id = newProduct.Id;
            productToAdd.Name = newProduct.Name;
            productToAdd.DefaultShelfLife = newProduct.DefaultShelfLife;
            dbContext.Add(productToAdd);
            dbContext.SaveChanges();
        }


        public void RemoveProduct(KnownProductsListVm productToRemove)
        {
            KnownProduct knownProduct = new KnownProduct();
            knownProduct.Id = productToRemove.Id;
            knownProduct.Name = productToRemove.Name;
            knownProduct.DefaultShelfLife = productToRemove.DefaultShelfLife;

            dbContext.Remove(knownProduct);
            dbContext.SaveChanges();
        }


       public async Task<KnownProductsListVm> GetProductById(int? id)
        {
            KnownProductsListVm knownProductVm = new KnownProductsListVm();
            List<KnownProduct> knownProducts = dbContext.KnownProducts.ToList();

            KnownProduct product =  dbContext.KnownProducts.FirstOrDefault( p => p.Id == id );
            knownProductVm.Id = product.Id;
            knownProductVm.Name = product.Name;
            knownProductVm.DefaultShelfLife = product.DefaultShelfLife;

            // TODO: FINISH THIS CUZ I DUNNO IF IT S FINISHED

            return knownProductVm;
        }
    }
}
