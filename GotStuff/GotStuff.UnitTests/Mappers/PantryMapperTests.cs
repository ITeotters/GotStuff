using GotStuff.Models;
using GotStuff.Services.Mappers;
using GotStuff.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GotStuff.UnitTests
{
    [TestClass]
    public class PantryMapperTests
    {
        private const int fakePantryId = 1;
        private const string fakePantryName = "Home";
        
        [TestMethod]
        public void NullModelReturnsNull()
        {
            PantryMapper mapper = new PantryMapper();

            var result = mapper.ToVm(null);

            Assert.IsNull(result);
        }


        [TestMethod]
        public void ValidModelReturnsExpectedPantryProperties()
        {
            // Arrange
            PantryMapper mapper = new PantryMapper();
            Pantry fakePantry = CreateFakePantry();

            // Act
            var result = mapper.ToVm(fakePantry);
            
            // Assert
            Assert.AreEqual(fakePantryId, result.Id);
            Assert.AreEqual(fakePantryName, result.Name);
        }


        [TestMethod]
        public void AppUsersNullResultsInNull()
        {
            PantryMapper mapper = new PantryMapper();
            //TODO
        }


        [TestMethod]
        public void ValidModelReturnsNotNull()
        {
            PantryMapper mapper = new PantryMapper();
            Pantry fakePantry = CreateFakePantry();

            var result = mapper.ToVm(fakePantry);

            Assert.IsNotNull(result);
        }


        private Pantry CreateFakePantry()
        {
            Pantry pantry = new Pantry()
            {
                Id = fakePantryId,
                Name = fakePantryName,
                AppUsers = new List<AppUser>()
                {
                    new AppUser()
                    {
                        Id = "123",
                        FullName = "Bob",
                        Email = "bob@bob.com"
                    },
                    new AppUser()
                    {
                        Id = "456",
                        FullName = "Meh",
                        Email = "meh@meh.com"
                    }
                }
            };

            return pantry;
        }
    }
}
