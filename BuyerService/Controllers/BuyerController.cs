using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BuyerDB.Repositories;
using BuyerDB.Models;
using BuyerDB.Entity;
using BuyerService.Manager;

namespace BuyerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerManager _buyerManager;
        public BuyerController(IBuyerManager buyerManager)
        {
            _buyerManager = buyerManager;
        }
        [HttpPost]
        [Route("EditProfile")]
        public async Task<IActionResult> EditBuyerProfile(BuyerData buyer)
        {
            return Ok(await _buyerManager.EditBuyerProfile(buyer));

        }
        [HttpGet]
        [Route("Profile/{buyerId}")]
        public async Task<IActionResult> GetBuyerProfile(int buyerId)
        {
            BuyerData buyer = await _buyerManager.GetBuyerProfile(buyerId);
            if (buyer == null)
                return Ok("Invalid User");
            else
            {
                return Ok(buyer);
            }
        }
        }
    }