using BuyerDB.Entity;
using BuyerDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuyerDB.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly BuyerDBContext _buyerContext;
        public BuyerRepository(BuyerDBContext buyerContext)
        {
            _buyerContext = buyerContext;
        }
        public async Task<bool> EditBuyerProfile(BuyerData buyer)
        {
            Buyer buyer1 = _buyerContext.Buyer.Find(buyer.buyerId);
            if (buyer1 != null)
            {
                buyer1.Username = buyer.userName;
                buyer1.Password = buyer.password;
                buyer1.Mobileno = buyer.mobileNo;
                buyer1.Email = buyer.emailId;
                _buyerContext.Buyer.Update(buyer1);
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
            else
                return false;
        }

        public async Task<BuyerData> GetBuyerProfile(int buyerId)
        {
            Buyer buyer = await _buyerContext.Buyer.FindAsync(buyerId);
            if (buyer == null)
                return null;
            else
            {
                BuyerData buyerData = new BuyerData();
                buyerData.buyerId = buyer.Buyerid;
                buyerData.userName = buyer.Username;
                buyerData.password = buyer.Password;
                buyerData.emailId = buyer.Email;
                buyerData.mobileNo = buyer.Mobileno;
                return buyerData;
            }
        }
    }
}
