using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BuyerDB.Entity;
using BuyerDB.Models;
using BuyerDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using UserService.Manager;
using Microsoft.Extensions.Logging;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserManager _userManager;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserManager userManager, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
       /* public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }*/
        /// <summary>
        /// Register buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Buyer(BuyerRegister buyer1)
        {

            _logger.LogInformation("Register");
            if (buyer1 is null)
            {
                return BadRequest("Buyer is already register");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _logger.LogInformation("Succesfully Registered");
            return Ok(await _userManager.BuyerRegister(buyer1));

        }
        /// <summary>
        /// Login Buyer
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> BuyerLogin(Login login)
        {
            _logger.LogInformation("User Login");

            Login login1 = await _userManager.BuyerLogin(login);
            if (login1 == null)
            {
                return Ok("Invalid User");
            }
            _logger.LogInformation($"Welcome{login.userName}");
            return Ok(login);
        }
    }
}
    
