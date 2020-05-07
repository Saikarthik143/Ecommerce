using BuyerDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyerService.Manager
{
   public interface IBuyerManager
    {
        Task<bool> EditBuyerProfile(Buyer buyer);
        Task<Buyer> GetBuyerProfile(string buyerId);
    }
}
