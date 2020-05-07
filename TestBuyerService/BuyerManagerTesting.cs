using BuyerDB.Entity;
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
                var result = await _buyerManager.GetBuyerProfile(buyerId);
                var mock = new Mock<IBuyerManager>();
                mock.Setup(x => x.GetBuyerProfile(buyerId));
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
                var result = await _buyerManager.GetBuyerProfile(buyerId);
                var mock = new Mock<IBuyerManager>();
                mock.Setup(x => x.GetBuyerProfile(buyerId));
                Assert.IsNull(result);
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
                Buyer buyer = await _buyerManager.GetBuyerProfile("B001");
                buyer.Mobileno = "9087654321";
                await _buyerManager.EditBuyerProfile(buyer);
                Buyer buyer1 = await _buyerManager.GetBuyerProfile("B001");
                var mock = new Mock<IBuyerManager>();
                mock.Setup(x => x.GetBuyerProfile("B001"));
                Assert.AreSame(buyer, buyer1);
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
                Buyer buyer = await _buyerManager.GetBuyerProfile("B0123");
                buyer.Email = "abc@gmail.com";
                await _buyerManager.EditBuyerProfile(buyer);
                Buyer buyer1 = await _buyerManager.GetBuyerProfile("6375");
                var mock = new Mock<IBuyerManager>();
                mock.Setup(x => x.GetBuyerProfile("B0123"));
                Assert.AreNotSame(buyer, buyer1);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

    }
}
