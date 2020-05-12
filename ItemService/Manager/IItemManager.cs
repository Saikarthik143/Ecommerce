//using BuyerDB.Entity;
using BuyerDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemService.Manager
{
    public interface IItemManager
    {
        Task<List<Product>> Search(string itemName);
       // Task<List<Product>> SearchItemByCategory(ProductCategory productCategory);
       // Task<List<Product>> SearchItemBySubCategory(ProductSubCategory productSubCategory);
        Task<bool> BuyItem(PurchaseHistory purchase);
         Task<List<PurchaseHistory>> Purchase(int buyerId);
       // Task<List<ProductCategory>> GetCategories();
        //Task<List<ProductSubCategory>> GetSubCategories(ProductCategory productCategory);
        Task<bool> AddToCart(AddToCart cart);
         Task<int> GetCount(int buyerid);
        Task<bool> CheckCartItem(int buyerid, int itemid);
        Task<List<AddToCart>> GetCarts(int buyerid);
        Task<bool> DeleteCart(int cartId);
        Task<AddToCart> GetCartItem(int cartid);
          Task<List<Product>> Items(int price, int price1);
    }
}
