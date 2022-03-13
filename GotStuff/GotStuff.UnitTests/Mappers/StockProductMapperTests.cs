using GotStuff.Models;
using GotStuff.Services.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GotStuff.UnitTests
{
    [TestClass]
    public class StockProductMapperTests
    {
        private const int stockProductDetailsId = 1;
        private const int productId = 2;
        private const int pantryId = 3;
        private readonly DateTime acquiredDate = DateTime.Now;
        private readonly DateTime expirationDate = DateTime.Now;
        private const string knownProductName = "test";


        [TestMethod]
        public void ValidModelReturnsNotNull()
        {
            StockProductMapper mapper = new StockProductMapper();
            StockProduct stockProduct = new StockProduct();

            var result = mapper.ToVm(stockProduct);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ValidModelReturnsExpectedProperties()
        {
            StockProductMapper mapper = new StockProductMapper();
            StockProduct stockProduct = new StockProduct()
            {
                Id = stockProductDetailsId,
                KnownProductId = productId,
                ExpirationDate = expirationDate,
                AcquiredDate = acquiredDate,
                PantryId = pantryId,
                KnownProduct = new KnownProduct()
                {
                    Id = 5,
                    Name = knownProductName,
                    DefaultShelfLife = 5
                }
            };

            var result = mapper.ToVm(stockProduct);

            Assert.AreEqual(stockProductDetailsId, result.StockProductDetailsId);
            Assert.AreEqual(productId, result.ProductId);
            Assert.AreEqual(pantryId, result.PantryId);
            Assert.AreEqual(acquiredDate, result.AcquiredDate);
            Assert.AreEqual(expirationDate, result.ExpirationDate);
            Assert.AreEqual(knownProductName, result.Name);
        }


        [TestMethod]
        public void NullModelReturnsNull()
        {
            StockProductMapper mapper = new StockProductMapper();

            var result = mapper.ToVm(null);

            Assert.IsNull(result);
        }

    }
}
