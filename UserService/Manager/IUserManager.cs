using BuyerDB.Entity;
using BuyerDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Manager
{
  public  interface IUserManager
    {
        Task<bool> BuyerRegister(BuyerRegister buyer);
        Task<Login> BuyerLogin(Login login);
    }
}
