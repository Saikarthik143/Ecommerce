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
    class BuyerManagerTesting
    {
        IBuyerManager _buyerManager;

        [SetUp]
        public void SetUp()
        {
            _buyerManager = new BuyerManager(new BuyerRepository(new BuyerContext()));
        }

        [TearDown]
        public void TearDown()
        {
            _buyerManager = null;
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [TestCase("B002")]
        [TestCase("B001")]
        [Description("testing buyer Profile")]
        public async Task BuyerProfile_Successfull(string buyerId)
        {
            try
            {
                BuyerData buyer = new BuyerData();
                var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.GetBuyerProfile(buyerId)).ReturnsAsync(buyer);
                BuyerManager buyerManager = new BuyerManager(mock.Object);
                var result = await buyerManager.GetBuyerProfile(buyerId);
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
                var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.GetBuyerProfile(buyerId));
                BuyerManager buyerManager = new BuyerManager(mock.Object);
                var result = await buyerManager.GetBuyerProfile(buyerId);
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
                var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.EditBuyerProfile(buyer)).ReturnsAsync(true);
                BuyerManager buyerManager = new BuyerManager(mock.Object);
                var result = await buyerManager.EditBuyerProfile(buyer);
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
                BuyerData buyer = new BuyerData() { buyerId ="B674", userName = "anvi", password = "abcdefg@", emailId = "anvi@gmail.com", mobileNo = "9873452567", dateTime = System.DateTime.Now };
                var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.EditBuyerProfile(buyer));
                BuyerManager buyerManager = new BuyerManager(mock.Object);
                var result = await buyerManager.EditBuyerProfile(buyer);
                Assert.IsNull(result,"Invalid");
                Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

    }
}
