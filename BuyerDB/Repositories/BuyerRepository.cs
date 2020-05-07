using BuyerDB.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuyerDB.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly BuyerContext _buyerContext;
        public BuyerRepository(BuyerContext buyerContext)
        {
            _buyerContext = buyerContext;
        }
        public async Task<bool> EditBuyerProfile(Buyer buyer)
        {
            _buyerContext.Update(buyer);
            var user = await _buyerContext.SaveChangesAsync();
            if (user > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Buyer> GetBuyerProfile(string buyerId)
        {
            Buyer buyer = await _buyerContext.Buyer.FindAsync(buyerId);
            if (buyer == null)
                return null;
            else
                return buyer;
        }
    }
}
