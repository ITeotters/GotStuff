using GotStuff.Data;
using GotStuff.Models;
using GotStuff.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GotStuff.Services.Implementation
{
    public class KnownProductsService : IKnownProductsService
    {
        private readonly ApplicationDbContext dbContext;

        public KnownProductsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<KnownProductVm> GetAllKnownProducts()
        {
            List<KnownProductVm> knownProductsVm = new List<KnownProductVm>();
            List<KnownProduct> knownProducts = dbContext.KnownProducts.ToList();

            foreach (KnownProduct product in knownProducts)
            {
                KnownProductVm productsVm = new KnownProductVm();
                productsVm.Id = product.Id;
                productsVm.Name = product.Name;
                productsVm.DefaultShelfLife = product.DefaultShelfLife;
                knownProductsVm.Add(productsVm);
            }

            return knownProductsVm;
        }


        public void AddNewProduct(KnownProductVm newProduct)
        {
            KnownProduct productToAdd = new KnownProduct();
            productToAdd.Id = newProduct.Id;
            productToAdd.Name = newProduct.Name;
            productToAdd.DefaultShelfLife = newProduct.DefaultShelfLife;
            dbContext.Add(productToAdd);
            dbContext.SaveChanges();
        }


        public async Task RemoveProduct(int id)
        {
            KnownProduct productToRemove = await GetProductById(id);

            dbContext.Remove(productToRemove);
            await dbContext.SaveChangesAsync();
        }


        public async Task<KnownProduct> GetProductById(int? id)
        {
            KnownProduct knownProduct = null;
            try
            {
                knownProduct = await dbContext.KnownProducts.FirstOrDefaultAsync(p => p.Id == id);
            } catch(Exception e)
            {
                GC.KeepAlive(e);
            }
            return knownProduct;
        }


        public async Task<KnownProductVm> GetProductVmById(int? id)
        {
            KnownProduct product = await GetProductById(id);
            KnownProductVm knownProductVm = new KnownProductVm();

            knownProductVm.Id = product.Id;
            knownProductVm.Name = product.Name;
            knownProductVm.DefaultShelfLife = product.DefaultShelfLife;

            return knownProductVm;
        }


        public async Task EditProduct(KnownProductVm updatedProduct)
        {
            KnownProduct productToEdit = await GetProductById(updatedProduct.Id);
            productToEdit.Id = updatedProduct.Id;
            productToEdit.Name = updatedProduct.Name;
            productToEdit.DefaultShelfLife = updatedProduct.DefaultShelfLife;

            await dbContext.SaveChangesAsync();
        }
    }
}
