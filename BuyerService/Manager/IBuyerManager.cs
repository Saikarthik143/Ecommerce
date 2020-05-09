﻿using BuyerDB.Entity;
using BuyerDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyerService.Manager
{
   public interface IBuyerManager
    {
        Task<bool> EditBuyerProfile(BuyerData buyer);
        Task<BuyerData> GetBuyerProfile(string buyerId);
    }
}
