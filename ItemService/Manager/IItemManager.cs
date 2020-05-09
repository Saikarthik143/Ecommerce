using BuyerDB.Entity;
using BuyerDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemService.Manager
{
   public interface IItemManager
    {
        Task<List<Items>> Search(Product product);
        Task<List<Items>> SearchItemByCategory(ProductCategory productCategory);
        Task<List<Items>> SearchItemBySubCategory(ProductSubCategory productSubCategory);
        Task<bool> BuyItem(PurchaseHistory purchase);
        // Task<List<Purchasehistory>> Purchase(PurchaseHistory purchaseHistory);
        Task<List<Category>> GetCategories();
        Task<List<SubCategory>> GetSubCategories(ProductCategory productCategory);
        Task<bool> AddToCart(AddToCart cart);
        // Task<int> GetCount(int buyerid);
        Task<bool> CheckCartItem(string buyerid, string itemid);
        Task<List<Cart>> GetCarts(string buyerid);
        Task<bool> DeleteCart(string cartId);
        Task<AddToCart> GetCartItem(string cartid);
        //   Task<List<Items>> Items(int price, int price1);
    }
}
