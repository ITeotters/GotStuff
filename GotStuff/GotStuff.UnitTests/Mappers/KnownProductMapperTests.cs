using GotStuff.Models;
using GotStuff.Services.Mappers;
using GotStuff.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GotStuff.UnitTests
{
    [TestClass]
    public class KnownProductMapperTests
    {
        private const int knownProductId = 1;
        private const int defaultShelfLife = 100;
        private const string knownProductName = "Aperol";

        [TestMethod]
        public void ValidModelReturnsNotNullToVM()
        {
            KnownProductMapper mapper = new KnownProductMapper();
            KnownProduct knownProduct = new KnownProduct();

            var result = mapper.ToVm(knownProduct);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ValidModelReturnsExpectedPropertiesToVm()
        {
            KnownProductMapper mapper = new KnownProductMapper();
            KnownProduct knownProduct = new KnownProduct()
            {
                Id = knownProductId,
                Name = knownProductName,
                DefaultShelfLife = defaultShelfLife
            };

            var result = mapper.ToVm(knownProduct);

            Assert.AreEqual(knownProductId, result.KnownProductId);
            Assert.AreEqual(knownProductName, result.Name);
            Assert.AreEqual(defaultShelfLife, result.DefaultShelfLife);
        }


        [TestMethod]
        public void ModelNullReturnsNullToVm()
        {
            KnownProductMapper mapper = new KnownProductMapper();

            var result = mapper.ToVm(null);

            Assert.IsNull(result);
        }


        [TestMethod]
        public void ValidModelReturnsNotNullFromVm()
        {
            KnownProductMapper mapper = new KnownProductMapper();
            KnownProductVm knownProductVm = new KnownProductVm();

            var result = mapper.FromVm(knownProductVm);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ValidModelExpectsCertainPropertiesFromVm()
        {
            KnownProductMapper mapper = new KnownProductMapper();
            KnownProductVm knownProductVm = new KnownProductVm()
            {
                KnownProductId = knownProductId,
                Name = knownProductName,
                DefaultShelfLife = defaultShelfLife
            };

            var result = mapper.FromVm(knownProductVm);

            Assert.AreEqual(knownProductId, result.Id);
            Assert.AreEqual(knownProductName, result.Name);
            Assert.AreEqual(defaultShelfLife, result.DefaultShelfLife);
        }


        [TestMethod]
        public void NullModelReturnsNullFromVm()
        {
            KnownProductMapper mapper = new KnownProductMapper();

            var result = mapper.FromVm(null);

            Assert.IsNull(result);
        }
    }
}
