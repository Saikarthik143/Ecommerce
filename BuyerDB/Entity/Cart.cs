using System;
using System.Collections.Generic;

namespace BuyerDB.Entity
{
    public partial class Cart
    {
        public string Cartid { get; set; }
        public string Categoryid { get; set; }
        public string Subid { get; set; }
        public string Buyerid { get; set; }
        public string Itemid { get; set; }
        public string Price { get; set; }
        public string Itemname { get; set; }
        public string Description { get; set; }
        public int? Stockno { get; set; }
        public string Remarks { get; set; }
        public string Imagename { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Category Category { get; set; }
        public virtual Items Item { get; set; }
        public virtual SubCategory Sub { get; set; }
    }
}
