using BuyerDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyerDB.Repositories;
using BuyerDB.Models;

namespace BuyerService.Manager
{
    public class BuyerManager : IBuyerManager
    {
        private readonly IBuyerRepository _buyerRepository;
        public BuyerManager(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }
        public async Task<bool> EditBuyerProfile(BuyerData buyer)
        {
            bool user = await _buyerRepository.EditBuyerProfile(buyer);
            if (user)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<BuyerData> GetBuyerProfile(string buyerId)
        {
            BuyerData buyer = await _buyerRepository.GetBuyerProfile(buyerId);
            if (buyer == null)
            {
                return null;
            }
            else
            {
                return buyer;
            }
        }
    }
}
