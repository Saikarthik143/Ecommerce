using BuyerDB.Entity;
using BuyerDB.Models;
using BuyerDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Login> BuyerLogin(Login login)
        {
            Buyer buyer = new Buyer();
            Login login1 = await _userRepository.BuyerLogin(login);
            if (buyer.Buyername == login.userName && buyer.Password == login.userPassword)
            {
                return login1;
            }
            else
            {
                Console.WriteLine("Invalid");
                return login1;
            }
        }

        public async Task<bool> BuyerRegister(Buyer buyer)
        {
            bool user = await _userRepository.BuyerRegister(buyer);
            return user;
        }
    }
}
