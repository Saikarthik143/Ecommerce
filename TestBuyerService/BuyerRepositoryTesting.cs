using BuyerDB.Entity;
using BuyerDB.Repositories;
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
                var mock = new Mock<IBuyerRepository>();
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
        [TestCase("b54")]
        [TestCase("b6")]
        [Description("testing buyer Profile failure")]
        public async Task BuyerProfile_UnSuccessfull(string buyerId)
        {
            try
            {
                var result = await buyerRepository.GetBuyerProfile(buyerId);
                var mock = new Mock<IBuyerRepository>();
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
                Buyer buyer = await buyerRepository.GetBuyerProfile("B001");
                buyer.Mobileno = "9701236576";
                await buyerRepository.EditBuyerProfile(buyer);
                Buyer buyer1 = await buyerRepository.GetBuyerProfile("B001");
                var mock = new Mock<IBuyerRepository>();
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
                
                Buyer buyer = await buyerRepository.GetBuyerProfile("B0123");
                buyer.Email = "abc@gmail.com";
                await buyerRepository.EditBuyerProfile(buyer);
                Buyer buyer1 = await buyerRepository.GetBuyerProfile("B678");
                var mock = new Mock<IBuyerRepository>();
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
    

