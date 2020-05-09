﻿using BuyerDB.Entity;
using BuyerDB.Models;
using BuyerDB.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserService.Manager;

namespace TestUserService
{
    [TestFixture]
  public  class UserManagerTesting
    {
        IUserManager userManager;
        [SetUp]
        public void SetUp()
        {
            userManager = new UserManager(new UserRepository(new BuyerContext()));
        }

        [TearDown]
        public void TearDown()
        {
            userManager = null;
        }
        /// <summary>
        /// Testing register buyer
        /// </summary>
        [Test]
        [TestCase("B7388", "jaya", "abcdefg2", "9365778295", "jaya@gmail.com")]
        [TestCase("B6499", "sai", "abcdefg2", "9462753495", "sai@gmail.com")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyer_Successfull(string buyerId, string userName, string password, string mobileNo, string email)
        {
            try
            {
                DateTime datetime = System.DateTime.Now;
                var buyer = new BuyerRegister { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId = email, dateTime = datetime };
                var mock = new Mock<IUserRepository>();
                mock.Setup(x => x.BuyerRegister(buyer)).ReturnsAsync(true);
                UserManager userManager1 = new UserManager(mock.Object);
                var result = await userManager1.BuyerRegister(buyer);
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Register Buyer Unscuccessful
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="mobileNo"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [Test]
        [TestCase("7366", "apple", "abcdefg2", "9365778295", "apple@gmail.com")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyer_UnSuccessfull(string buyerId, string userName, string password, string mobileNo, string email)
        {
            try
            {
                DateTime datetime = System.DateTime.Now;
                var buyer = new BuyerRegister { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId = email, dateTime = datetime };
                var mock = new Mock<IUserRepository>();
                mock.Setup(x => x.BuyerRegister(buyer)).ReturnsAsync(false);
                UserManager userManager1 = new UserManager(mock.Object);
                var result = await userManager1.BuyerRegister(buyer);
                Assert.IsNotNull(result);
                Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// buyerLogin
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("Karthik", "karthik123")]
        [Description("testing buyer login")]
        public async Task BuyerLogin_Successfull(string userName, string password)
        {
            try
            {
                var login = new Login { userName = userName, userPassword = password };
                var result = await userManager.BuyerLogin(login);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Buyer Login Unsuccessfull
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("inik", "abcdef")]
        [Description("Test buyer login failure case")]
        public async Task BuyerLogin_UnSuccessfull(string userName, string password)
        {
            try
            {
                Login login = new Login { userName = userName, userPassword = password };
                var result = await userManager.BuyerLogin(login);
                Assert.IsNull(result,"invalid credentials");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
