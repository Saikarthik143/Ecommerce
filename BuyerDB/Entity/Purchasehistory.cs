using System;
using System.Collections.Generic;

namespace BuyerDB.Entity
{
    public partial class Purchasehistory
    {
        public string Purchaseid { get; set; }
        public string Buyerid { get; set; }
        public string Transactiontype { get; set; }
        public string Itemid { get; set; }
        public int? Noofitems { get; set; }
        public DateTime Datetime { get; set; }
        public string Remarks { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Items Item { get; set; }
    }
}
