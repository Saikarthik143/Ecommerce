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

namespace TestUserService
{
    [TestFixture]
   public class UserControllerTesting
    {
       private UserController userController;
        private Mock<IUserManager> mockUserManager;
        private Mock<ILogger<UserController>> logger;
        [SetUp]
        public void SetUp()
        {
            mockUserManager = new Mock<IUserManager>();
            logger = new Mock<ILogger<UserController>>();
            userController = new UserController( mockUserManager.Object, logger.Object);
        }

        [Test]
        [TestCase("b985", "lohit", "abcdefg@", "krish@gmail.com", "9358778295")]
        [TestCase("b132", "devar", "abcdefg@", "sri@gmail.com", "9462623495")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyerController_Successfull(string buyerId, string userName, string password, string email, string mobileNo)
        {
            try
            {
                DateTime dateTime = System.DateTime.Now;
                BuyerRegister buyerRegister = new BuyerRegister() { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId = email, dateTime = dateTime };
                mockUserManager.Setup(d => d.BuyerRegister(buyerRegister)).ReturnsAsync(true);
                IActionResult result = await userController.Buyer(buyerRegister);
                Assert.IsNotNull(result);
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
        [TestCase("Karthik", "karthik123")]
        [Description("Buyer Login")]
        public async Task BuyerLogin_Successfull(string userName, string password)
        {
            try
            {
                Login login = new Login() { userName = userName, userPassword = password };
                mockUserManager.Setup(d => d.BuyerLogin(login)).ReturnsAsync(login);
                IActionResult result = await userController.BuyerLogin(login);
                var contentResult = result as OkNegotiatedContentResult<Login>;
                Assert.IsNotNull(contentResult);
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
                Login login = new Login() { userName = userName, userPassword = password };
                mockUserManager.Setup(d => d.BuyerLogin(login)).ReturnsAsync(login);
                IActionResult result = await userController.BuyerLogin(login);
                var contentResult = result as OkNegotiatedContentResult<Login>;
                Assert.IsNull(result);
                Assert.IsNull(contentResult, "Invalid User");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
