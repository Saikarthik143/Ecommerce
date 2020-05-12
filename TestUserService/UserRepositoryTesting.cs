using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BuyerDB.Entity;
using BuyerDB.Models;
using BuyerDB.Repositories;
using System.Threading.Tasks;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace TestUserService
{
    [TestFixture]
    class UserRepositoryTesting
    {
        IUserRepository userRepository;
        DbContextOptionsBuilder<BuyerDBContext> _builder;
        [SetUp]
        public void SetUp()
        {
            _builder = new DbContextOptionsBuilder<BuyerDBContext>().EnableSensitiveDataLogging().UseInMemoryDatabase(Guid.NewGuid().ToString());
            BuyerDBContext db = new BuyerDBContext(_builder.Options);
            userRepository = new UserRepository(db);
        }
        [TearDown]
        public void TearDown()
        {
            userRepository = null;
        }
        /// <summary>
        /// Testing register buyer
        /// </summary>
        [Test]
        [TestCase(12, "gopi", "sarath123#", "sarath@gmail.com", "9876543210")]
        [TestCase(14, "nath", "trath123#", "tarath@gmail.com", "9879543210")]
        [Description("Add Buyer Testing")]
        public async Task RegisterBuyer_Successfull(int buyerId, string userName, string password, string email, string mobileNo)
        {
            try
            {
                DateTime datetime = System.DateTime.Now;
                var buyer = new BuyerRegister { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId = email, dateTime = datetime };
                var mock = new Mock<IUserRepository>();
                mock.Setup(x => x.BuyerRegister(buyer)).ReturnsAsync(true);
                var result = await userRepository.BuyerRegister(buyer);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.InnerException.Message);
            }
        }
        [Test]
        [TestCase("Karthik", "karthik@123")]
        [Description("testing buyer login")]
        public async Task BuyerLogin_Successfull(string userName, string password)
        {
            try
            {
                
                var result = await userRepository.BuyerLogin(userName,password);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.InnerException.Message);
            }
        }
        [Test]
        [TestCase("tath", "trath123")]
        [Description("Test buyer login failure case")]
        public async Task BuyerLogin_UnSuccessfull(string userName, string password)
        {
            try
            {
                var result = await userRepository.BuyerLogin(userName,password);
                Assert.IsNull(result, "invalid credentials");
            }
            catch (Exception e)
            {
                Assert.Fail(e.InnerException.Message);
            }
        }
    }

}
