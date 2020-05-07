using System;
using System.Collections.Generic;

namespace BuyerDB.Entity
{
    public partial class Buyer
    {
        public Buyer()
        {
            Cart = new HashSet<Cart>();
            Purchasehistory = new HashSet<Purchasehistory>();
        }

        public string Buyerid { get; set; }
        public string Buyername { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobileno { get; set; }
        public DateTime? Datetime { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Purchasehistory> Purchasehistory { get; set; }
    }
}
