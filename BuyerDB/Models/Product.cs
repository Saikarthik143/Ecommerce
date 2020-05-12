using System;
using System.Collections.Generic;
using System.Text;

namespace BuyerDB.Models
{
  public  class Product
    {
        public string productName { get; set; }
        public int? productId { get; set; }
        public string categoryId { get; set; }
        public string subCategoryId { get; set; }
        public int? price { get; set; }
        public string description { get; set; }
        public int? stockno { get; set; }
        public string remarks { get; set; }
        public string imageName { get; set; }
        public string categoryName { get; set; }
        public string subCategoryName { get; set; }
    }
}
