using System;
using System.Collections.Generic;
using System.Text;

namespace BuyerDB.Models
{
   public class AddToCart
    {
        public string cartId { get; set; }
        public string categoryId { get; set; }
        public string subCategoryId { get; set; }
        public string buyerId { get; set; }
        public string itemId { get; set; }
        public string price { get; set; }
        public string itemName { get; set; }
        public string description { get; set; }
        public int? stockNo { get; set; }
        public string remarks { get; set; }
        public string imageName { get; set; }
    }
}
