using BuyerDB.Entity;
using BuyerDB.Models;
using BuyerDB.Repositories;
using BuyerService.Controllers;
using BuyerService.Manager;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestBuyerService
{
  public  class BuyerControllerTesting
    {
        BuyerController buyerController;
        [SetUp]
        public void SetUp()
        {
            buyerController = new BuyerController(new BuyerManager(new BuyerRepository(new BuyerContext())));
        }

        [TearDown]
        public void TearDown()
        {
            buyerController = null;
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
                BuyerData buyer = new BuyerData();
                var mock = new Mock<IBuyerManager>();
                mock.Setup(x => x.GetBuyerProfile(buyerId)).ReturnsAsync(buyer);
                BuyerController buyerController1 = new BuyerController(mock.Object);
                var result = await buyerController1.GetBuyerProfile(buyerId);
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
        [TestCase("458")]
        [TestCase("322")]
        [Description("testing buyer Profile failure")]
        public async Task BuyerProfile_UnSuccessfull(string buyerId)
        {
            try
            {
                var mock = new Mock<IBuyerManager>();
                mock.Setup(x => x.GetBuyerProfile(buyerId));
                BuyerController buyerController1 = new BuyerController(mock.Object);
                var result = await buyerController1.GetBuyerProfile(buyerId);
                Assert.IsNull(result, "Invalid User");
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
                var mock = new Mock<IBuyerManager>();
                mock.Setup(x => x.EditBuyerProfile(buyer)).ReturnsAsync(true);
                BuyerController buyerController = new BuyerController(mock.Object);
                var result = await buyerController.EditBuyerProfile(buyer);
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
                BuyerData buyer = new BuyerData() { buyerId = "B071", userName = "Karthik", password = "karthik123", emailId = "Karthik@gmail.com", mobileNo = "9873452567", dateTime = System.DateTime.Now };
                var mock = new Mock<IBuyerManager>();
                mock.Setup(x => x.EditBuyerProfile(buyer));
                BuyerController buyerController = new BuyerController(mock.Object);
                var result = await buyerController.EditBuyerProfile(buyer);
                Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
    }
}