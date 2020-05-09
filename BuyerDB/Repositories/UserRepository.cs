using BuyerDB.Entity;
using BuyerDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuyerDB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BuyerContext _buyerContext;
        public UserRepository(BuyerContext buyerContext)
        {
            _buyerContext = buyerContext;
        }
        public async Task<Login> BuyerLogin(Login login)
        {
            Buyer buyer = await _buyerContext.Buyer.SingleOrDefaultAsync(e => e.Buyername == login.userName && e.Password == login.userPassword);
            if (buyer!=null)
            {
                return login;
            }
            else
            {
                Console.WriteLine("Not valid");
                return null;
            }
        }

        public async Task<bool> BuyerRegister(BuyerRegister buyer)
        {
            Buyer buyer1 = new Buyer();
            if (buyer != null)
            {
                buyer1.Buyerid = buyer.buyerId;
                buyer1.Buyername = buyer.userName;
                buyer1.Password = buyer.password;
                buyer1.Mobileno = buyer.mobileNo;
                buyer1.Email = buyer.emailId;
                buyer1.Datetime = buyer.dateTime;
            }
            _buyerContext.Buyer.Add(buyer1);
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
    }
}
