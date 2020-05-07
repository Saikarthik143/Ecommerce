using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BuyerDB.Entity;
using BuyerDB.Models;
using BuyerDB.Repositories;
using System.Threading.Tasks;
using Moq;

namespace TestUserService
{
    [TestFixture]
    class UserRepositoryTesting
    {
        IUserRepository userRepository;
        [SetUp]
        public void SetUp()
        {
            userRepository = new UserRepository(new BuyerContext());
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
        [TestCase("B43", "iath", "sarath123#", "sarath@gmail.com", "9876543210")]
        [TestCase("B13", "tharath", "trath123#", "tarath@gmail.com", "9879543210")]
        [Description("Add Buyer Testing")]
        public async Task RegisterBuyer_Successfull(string buyerId, string userName, string password, string email, string mobileNo)
        {
            try
            {
                DateTime datetime = System.DateTime.Now;
                var buyer = new Buyer { Buyerid = buyerId, Buyername = userName, Password = password, Email = email, Mobileno = mobileNo, Datetime = datetime };
                await userRepository.BuyerRegister(buyer);
                var mock = new Mock<IUserRepository>();
                mock.Setup(x => x.BuyerRegister(buyer));
                var login = new Login { userName = userName, userPassword = password };
                var result = await userRepository.BuyerLogin(login);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.InnerException.Message);
            }
        }
        [Test]
        [TestCase("Karthik", "karthik123")]
        [Description("testing buyer login")]
        public async Task BuyerLogin_Successfull(string userName, string password)
        {
            try
            {
                var login = new Login { userName = userName, userPassword = password };
                var result = await userRepository.BuyerLogin(login);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.InnerException.Message);
            }
        }
        [Test]
        [TestCase("tarath", "trath123")]
        [Description("Test buyer login failure case")]
        public async Task BuyerLogin_UnSuccessfull(string userName, string password)
        {
            try
            {
                var login = new Login { userName = userName, userPassword = password };
                var result = await userRepository.BuyerLogin(login);
                Assert.AreEqual(null, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.InnerException.Message);
            }
        }
    }

}
