﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BuyerDB.Models
{
   public class AddToCart
    {
        public int cartId { get; set; }
       
        public int? buyerId { get; set; }
        public int? itemId { get; set; }
        public int price { get; set; }
        public string itemName { get; set; }
        public string description { get; set; }
        public int? stockNo { get; set; }
        public string remarks { get; set; }
        public string imageName { get; set; }
    }
}
