using System;
using System.Collections.Generic;

namespace BuyerDB.Entity
{
    public partial class Items
    {
        public Items()
        {
            Cart = new HashSet<Cart>();
            Purchasehistory = new HashSet<Purchasehistory>();
        }

        public string Itemid { get; set; }
        public string Categoryid { get; set; }
        public string Subid { get; set; }
        public string Price { get; set; }
        public string Itemname { get; set; }
        public string Description { get; set; }
        public int? Stockno { get; set; }
        public string Remarks { get; set; }

        public virtual Category Category { get; set; }
        public virtual SubCategory Sub { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Purchasehistory> Purchasehistory { get; set; }
    }
}
