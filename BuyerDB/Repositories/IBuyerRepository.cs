using BuyerDB.Entity;
using BuyerDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuyerDB.Repositories
{
    public interface IBuyerRepository
    {
        Task<bool> EditBuyerProfile(BuyerData buyer);
        Task<BuyerData> GetBuyerProfile(int buyerId);
    }
}
