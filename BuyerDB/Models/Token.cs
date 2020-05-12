using System;
using System.Collections.Generic;
using System.Text;

namespace BuyerDB.Models
{
   public class Token
    {
        public string username { get; set; }
        public string token { get; set; }
        public string message { get; set; }
        public int buyerid { get; set; }
    }
}
