using BuyerDB.Entity;
using BuyerDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyerDB.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly BuyerContext _buyerContext;
        public ItemRepository(BuyerContext buyerContext)
        {
            _buyerContext = buyerContext;
        }
        public async Task<bool> AddToCart(Cart cart)
        {
            _buyerContext.Cart.Add(cart);
            var buyerCart = await _buyerContext.SaveChangesAsync();
            if (buyerCart > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> BuyItem(Purchasehistory purchase)
        {
            _buyerContext.Purchasehistory.Add(purchase);
            var item = await _buyerContext.SaveChangesAsync();
            if (item > 0)
                return true;
            else
                return false;

        }

        public async Task<bool> CheckCartItem(string buyerId, string itemId)
        {
            Cart cart = await _buyerContext.Cart.SingleOrDefaultAsync(e => e.Buyerid == buyerId && e.Itemid == itemId);
            if (cart != null)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteCart(string cartId)
        {
            Cart cart = await _buyerContext.Cart.FindAsync(cartId);
            _buyerContext.Cart.Remove(cart);
            var item = await _buyerContext.SaveChangesAsync();
            if (item == null)
                return true;
            else
                return false;
        }

        public async Task<Cart> GetCartItem(string cartId)
        {
            return await _buyerContext.Cart.FindAsync(cartId);
        }

        public async Task<List<Cart>> GetCarts(string buyerId)
        {
            return await _buyerContext.Cart.Where(e => e.Buyerid == buyerId).ToListAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _buyerContext.Category.ToListAsync();
        }

        public async Task<int> GetCount(string buyerId)
        {
            var count = await _buyerContext.Cart.Where(e => e.Buyerid == buyerId).ToListAsync();
            return count.Count();
        }

        public async Task<List<Items>> GetItems()
        {
            return await _buyerContext.Items.ToListAsync();
        }

        public async Task<List<SubCategory>> GetSubCategories(string categoryId)
        {
            return await _buyerContext.SubCategory.Where(e => e.Categoryid == categoryId).ToListAsync();
        }

        public async Task<List<Items>> Items(string price, string price1)
        {

            throw new NotImplementedException();
        }

        public async Task<List<Purchasehistory>> Purchase(Login login)
        {
            return await _buyerContext.Purchasehistory.Where(e => e.Buyerid == login.buyerId).ToListAsync();
        }

        public async Task<List<Items>> Search(Product product)
        {
            return await _buyerContext.Items.Where(e => e.Itemname == product.productName).ToListAsync();
        }

        public async Task<List<Items>> SearchItemByCategory(ProductCategory productCategory)
        {
            return await _buyerContext.Items.Where(e => e.Itemname == productCategory.categoryName).ToListAsync();
        }

        public async Task<List<Items>> SearchItemBySubCategory(ProductSubCategory productSubCategory)
        {
            return await _buyerContext.Items.Where(e => e.Itemname == productSubCategory.subCategoryName).ToListAsync();
        }
    }
}
