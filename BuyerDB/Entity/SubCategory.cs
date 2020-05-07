using System;
using System.Collections.Generic;

namespace BuyerDB.Entity
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Cart = new HashSet<Cart>();
            Items = new HashSet<Items>();
        }

        public string Subid { get; set; }
        public string Subname { get; set; }
        public string Categoryid { get; set; }
        public string Subdetails { get; set; }
        public int? Gst { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
