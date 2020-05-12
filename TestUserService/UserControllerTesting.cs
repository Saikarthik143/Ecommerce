using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BuyerDB.Entity;
using BuyerDB.Models;
using BuyerDB.Repositories;
using UserService.Controllers;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Mvc;
using UserService.Manager;
using Microsoft.Extensions.Logging;
using System.Web.Http.Results;
using Microsoft.Extensions.Configuration;

namespace TestUserService
{
    [TestFixture]
   public class UserControllerTesting
    {
       private UserController userController;
        private Mock<IUserManager> mockUserManager;
        private Mock<ILogger<UserController>> logger;
        private IConfiguration configuration;
        [SetUp]
        public void SetUp()
        {
            mockUserManager = new Mock<IUserManager>();
            logger = new Mock<ILogger<UserController>>();
            userController = new UserController( mockUserManager.Object, logger.Object,configuration);
        }

        [Test]
        [TestCase(985, "lohit", "abcdefg@", "krish@gmail.com", "9358778295")]
        [TestCase(132, "devar", "abcdefg@", "sri@gmail.com", "9462623495")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyerController_Successfull(int buyerId, string userName, string password, string email, string mobileNo)
        {
            try
            {
                DateTime dateTime = System.DateTime.Now;
                mockUserManager.Setup(x => x.BuyerRegister(It.IsAny<BuyerRegister>())).ReturnsAsync(new bool());
                BuyerRegister buyerRegister = new BuyerRegister() { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId = email, dateTime = dateTime };
                var result = await userController.Buyer(buyerRegister) as OkObjectResult;
                Assert.That(result, Is.Not.Null);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Buyer Login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("Karthik", "karthik@123")]
        [Description("Buyer Login")]
        public async Task BuyerLogin_Successfull(string userName, string password)
        {
            try
            {
                mockUserManager.Setup(x => x.BuyerLogin(userName, password));
                var result = await userController.BuyerLogin(userName, password) as OkObjectResult;
                Assert.That(result, Is.Not.Null);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Buyer Login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("abc", "abcdefg@")]
        [Description("Buyer Login")]
        public async Task BuyerLogin_UnSuccessfull(string userName, string password)
        {
            try
            {
                mockUserManager.Setup(d => d.BuyerLogin(userName, password));
                IActionResult result = await userController.BuyerLogin(userName, password);
                Assert.IsNull(result);
                Assert.IsNull(result, "Invalid User");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
