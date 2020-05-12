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
        private readonly BuyerDBContext _buyerContext;
        public UserRepository(BuyerDBContext buyerContext)
        {
            _buyerContext = buyerContext;
        }
        public async Task<Login> BuyerLogin(string userName, string password)
        {
            Buyer buyer = await _buyerContext.Buyer.SingleOrDefaultAsync(e => e.Username == userName && e.Password == password);
            if (buyer != null)
            {
                return new Login
                {
                    userName = buyer.Username,
                    userPassword = buyer.Password,
                    buyerId = buyer.Buyerid,
                };
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
                buyer1.Username = buyer.userName;
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
