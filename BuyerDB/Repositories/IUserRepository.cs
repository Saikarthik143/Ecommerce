using BuyerDB.Entity;
using BuyerDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuyerDB.Repositories
{
    public interface IUserRepository
    {
        Task<bool> BuyerRegister(Buyer buyer);
        Task<Login> BuyerLogin(Login login);
    }
}
