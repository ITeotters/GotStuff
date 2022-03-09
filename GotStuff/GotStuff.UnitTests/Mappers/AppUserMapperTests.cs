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
            AppUser user = new AppUser();
            user.Id = "1234xyz";
            user.FullName = "John Bob";
            user.Email = "john@bob.com";
            var result = mapper.ToVm(user);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ValidModelReturnsExpectedProperties()
        {
            AppUserMapper mapper = new AppUserMapper();
            AppUser user = new AppUser();
            user.Id = "1234xyz";
            user.FullName = "John Bob";
            user.Email = "john@bob.com";
            var result = mapper.ToVm(user);
            Assert.AreEqual(result.Id, user.Id);
            Assert.AreEqual(result.FullName, user.FullName);
            Assert.AreEqual(result.EmailAddress, user.Email);
        }
    }
}