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
        Task<List<Items>> Search(Product product);
        Task<List<Items>> SearchItemByCategory(ProductCategory productCategory);
        Task<List<Items>> SearchItemBySubCategory(ProductSubCategory productSubCategory);
        Task<bool> BuyItem(Purchasehistory purchase);
        Task<List<Purchasehistory>> Purchase(Login login);
        Task<List<Category>> GetCategories();
        Task<List<SubCategory>> GetSubCategories(string categoryId);
        Task<List<Items>> GetItems();
        Task<bool> AddToCart(Cart cart);
        Task<int> GetCount(string buyerId);
        Task<bool> CheckCartItem(string buyerId, string itemId);
        Task<List<Cart>> GetCarts(string buyerId);
        Task<bool> DeleteCart(string cartId);
        Task<Cart> GetCartItem(string cartId);
        Task<List<Items>> Items(string price, string price1);
    }
}

    

