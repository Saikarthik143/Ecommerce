using System;
using System.Collections.Generic;
using System.Text;

namespace BuyerDB.Models
{
  public  class PurchaseHistory
    {
        public string purchaseId { get; set; }
        public string buyerId { get; set; }
        public string transactionType { get; set; }
        public string itemId { get; set; }
        public int noOfItems { get; set; }
        public DateTime dateTime { get; set; }
        public string remarks { get; set; }
        public string transactionStatus { get; set; }

    }
}
