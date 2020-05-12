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
        readonly List<Buyer> buyers = new List<Buyer>();
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Login> BuyerLogin(string userName, string password)
        {
            Login login1 = await _userRepository.BuyerLogin(userName,password);
            if (login1 != null)
            {
                return login1;
            }
            else
            {
                Console.WriteLine("Invalid");
                return null;
            }
        }

        public async Task<bool> BuyerRegister(BuyerRegister buyer)
        {
            Buyer buyer1 = new Buyer();
            var result = buyers.Where(i => i.Email.ToString() == buyer1.Email.ToString()).Select(i => i).ToList();
            //var result = (from i in buyers select i).ToList();
            if (result.Count > 1)
            {
                return false;
            }
            else
            {

                bool user = await _userRepository.BuyerRegister(buyer);
                return user;
            }
        }
    }
}
