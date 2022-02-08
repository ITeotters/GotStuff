﻿using GotStuff.Data;
using GotStuff.Models;
using GotStuff.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GotStuff.Services.Implementation
{
    public class KnownProductService : IKnownProductService
    {
        private readonly ApplicationDbContext dbContext;

        public KnownProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<KnownProductVm>> GetAllKnownProducts()
        {
            List<KnownProductVm> knownProductsVm = new List<KnownProductVm>();
            List<KnownProduct> knownProducts = await dbContext.KnownProduct.ToListAsync();

            foreach (KnownProduct product in knownProducts)
            {
                KnownProductVm productsVm = new KnownProductVm();
                productsVm.KnownProductId = product.Id;
                productsVm.Name = product.Name;
                productsVm.DefaultShelfLife = product.DefaultShelfLife;
                knownProductsVm.Add(productsVm);
            }

            return knownProductsVm;
        }


        public bool CheckIfProductExists(KnownProductVm newProduct)
        {
            var existingNameProduct = dbContext.KnownProduct
                .Where(product => product.Name == newProduct.Name)
                .FirstOrDefault();

            bool isProductExisting = existingNameProduct != null;

            return isProductExisting;
        }


        public async Task AddNewProduct(KnownProductVm newProduct)
        {
            KnownProduct productToAdd = new KnownProduct();
            productToAdd.Id = newProduct.KnownProductId;
            productToAdd.Name = newProduct.Name;
            productToAdd.DefaultShelfLife = newProduct.DefaultShelfLife;

            dbContext.Add(productToAdd);
            await dbContext.SaveChangesAsync();
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
                knownProduct = await dbContext.KnownProduct.FirstOrDefaultAsync(p => p.Id == id);
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

            knownProductVm.KnownProductId = product.Id;
            knownProductVm.Name = product.Name;
            knownProductVm.DefaultShelfLife = product.DefaultShelfLife;

            return knownProductVm;
        }


        public async Task EditProduct(KnownProductVm updatedProduct)
        {
            KnownProduct productToEdit = await GetProductById(updatedProduct.KnownProductId);
            productToEdit.Id = updatedProduct.KnownProductId;
            productToEdit.Name = updatedProduct.Name;
            productToEdit.DefaultShelfLife = updatedProduct.DefaultShelfLife;

            await dbContext.SaveChangesAsync();
        }
    }
}
