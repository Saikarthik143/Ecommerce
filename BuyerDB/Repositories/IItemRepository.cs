using BuyerDB.Entity;
using BuyerDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuyerDB.Repositories
{
    public interface IItemRepository
    {
        Task<List<Product>> Search(string itemName);
       // Task<List<Product>> SearchItemByCategory(ProductCategory productCategory);
       // Task<List<Product>> SearchItemBySubCategory(ProductSubCategory productSubCategory);
        Task<bool> BuyItem(PurchaseHistory purchase);
        Task<List<PurchaseHistory>> Purchase(int buyerId);
       // Task<List<ProductCategory>> GetCategories();
       // Task<List<ProductSubCategory>> GetSubCategories(ProductCategory productCategory);
        Task<List<Items>> GetItems();
        Task<bool> AddToCart(AddToCart cart);
        Task<int> GetCount(int buyerId);
        Task<bool> CheckCartItem(int buyerId, int itemId);
        Task<List<AddToCart>> GetCarts(int buyerId);
        Task<bool> DeleteCart(int cartId);
        Task<AddToCart> GetCartItem(int cartId);
        Task<List<Product>> Items(int price,int price1);
    }
}



