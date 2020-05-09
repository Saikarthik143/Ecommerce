using BuyerDB.Entity;
using BuyerDB.Models;
using BuyerDB.Repositories;
using BuyerService.Manager;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestBuyerService
{
    [TestFixture]
    class BuyerRepositoryTesting
    {
        IBuyerRepository buyerRepository;
        //IUserManager iUserManager;
        [SetUp]
        public void SetUp()
        {
            buyerRepository = new BuyerRepository(new BuyerContext());
        }

        [TearDown]
        public void TearDown()
        {
            buyerRepository = null;
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [TestCase("B001")]
        [TestCase("B002")]
        [Description("testing buyer Profile")]
        public async Task BuyerProfile_Successfull(string buyerId)
        {
            try
            {
                var result = await buyerRepository.GetBuyerProfile(buyerId);
               /* var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.GetBuyerProfile(buyerId));*/
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [TestCase("b54")]
        [TestCase("b6")]
        [Description("testing buyer Profile failure")]
        public async Task BuyerProfile_UnSuccessfull(string buyerId)
        {
            try
            {
                var result = await buyerRepository.GetBuyerProfile(buyerId);
               /* var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.GetBuyerProfile(buyerId));*/
                var result1 = await buyerRepository.GetBuyerProfile(buyerId);
                Assert.IsNull(result1,"Invalid");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [Description("testing buyer edit Profile")]
        public async Task EditBuyerProfile_Successfull()
        {
            try
            {
                BuyerData buyer = new BuyerData() { buyerId = "B001", userName = "Karthik", password = "karthik123", emailId = "Karthik@gmail.com", mobileNo = "9873452567", dateTime = System.DateTime.Now };
               /* var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.EditBuyerProfile(buyer)).ReturnsAsync(true);*/
                var result = await buyerRepository.EditBuyerProfile(buyer);
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [Description("testing buyer edit Profile")]
        public async Task EditBuyerProfile_UnSuccessfull()
        {
            try
            {

                BuyerData buyer = new BuyerData() { buyerId = "B01", userName = "Karthik", password = "karthik123", emailId = "Karthik@gmail.com", mobileNo = "9873452567", dateTime = System.DateTime.Now };
             /*   var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.EditBuyerProfile(buyer));*/
                var result = await buyerRepository.EditBuyerProfile(buyer);
                Assert.IsNull(result,"invalid");
                Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
    }
}
    

