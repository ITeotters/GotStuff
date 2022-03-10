using GotStuff.Models;
using GotStuff.Services.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GotStuff.UnitTests
{
    [TestClass]
    public class AppUserMapperTests
    {
        [TestMethod]
        public void ValidModelReturnsNotNull()
        {
            AppUserMapper mapper = new AppUserMapper();
            AppUser user = new AppUser()
            {
                Id = "1234xyz",
                FullName = "John Bob",
                Email = "john@bob.com"
            };

            var result = mapper.ToVm(user);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ValidModelReturnsExpectedProperties()
        {
            string id = "1234xyz";
            string fullName = "bob";
            string email = "bob@bob.com";

            AppUserMapper mapper = new AppUserMapper();
            AppUser user = new AppUser()
            {
                Id = id,
                FullName = fullName,
                Email = email
            };

            var result = mapper.ToVm(user);

            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(fullName, result.FullName);
            Assert.AreEqual(email, result.EmailAddress);
        }


        [TestMethod]
        public void ModelNullReturnsNull()
        {
            // Arrange
            AppUserMapper mapper = new AppUserMapper();

            // Act
            var result = mapper.ToVm(null);

            // Assert
            Assert.IsNull(result);
        }
    }
}