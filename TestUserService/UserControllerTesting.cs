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

namespace TestUserService
{
    [TestFixture]
   public class UserControllerTesting
    {
        UserController userController;

        [Test]
        [TestCase("b185", "krdeish", "abcdefg@", "krish@gmail.com", "9358778295")]
        [TestCase("b152", "srifd", "abcdefg@", "sri@gmail.com", "9462623495")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyerController_Successfull(string buyerId, string userName, string password, string email, string mobileNo)
        {
            DateTime datetime = System.DateTime.Now;
            Buyer buyer = new Buyer { Buyerid = buyerId, Buyername = userName, Password = password, Email = email, Mobileno = mobileNo, Datetime = datetime };
            await userController.Buyer(buyer);
            var mock = new Mock<UserController>();
            mock.Setup(x => x.Buyer(buyer));
            var login = new Login { userName = userName, userPassword = password };
            Task<IActionResult> result1 = userController.BuyerLogin(login);
            // var okResult = result as ObjectResult;
            Assert.NotNull(result1);
        }

    }
}
