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
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserManager _userManager;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration configuration;
        public UserController(IUserManager userManager, ILogger<UserController> logger,IConfiguration configuration)
        {
            _userManager = userManager;
            _logger = logger;
            this.configuration = configuration;
        }
      
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
        [HttpGet]
        [Route("Login/{userName}/{password}")]
        public async Task<IActionResult> BuyerLogin(string userName, string password)
        {
            Token token = null;
            _logger.LogInformation("User Login");

            Login login1 = await _userManager.BuyerLogin(userName, password);
            if (login1 != null)
            {
                token = new Token() { buyerid = login1.buyerId, username = login1.userName, token = GenerateJwtToken(userName), message = "Success" };
            }
            else
            {
                token = new Token() { token = null, message = "UnSuccess" };
            }
            _logger.LogInformation($"Welcome{userName}");
            return Ok(token);
        }
        private string GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, username),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Role,username)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // recommended is 5 min
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
    
