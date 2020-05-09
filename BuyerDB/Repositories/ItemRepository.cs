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
        public async Task<bool> AddToCart(AddToCart cart)
        {
            Cart cart1 = new Cart();
            if (cart != null)
            {
                cart1.Cartid = cart.cartId;
                cart1.Categoryid = cart.categoryId;
                cart1.Subid = cart.subCategoryId;
                cart1.Buyerid = cart.buyerId;
                cart1.Itemid = cart.itemId;
                cart1.Price = cart.price;
                cart1.Itemname = cart.itemName;
                cart1.Description = cart.description;
                cart1.Stockno = cart.stockNo;
                cart1.Remarks = cart.remarks;
                cart1.Imagename = cart.imageName;
            }
            _buyerContext.Cart.Add(cart1);
            var buyercart = await _buyerContext.SaveChangesAsync();
            if (buyercart > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> BuyItem(PurchaseHistory purchase)
        {
            Purchasehistory purchasehistory = new Purchasehistory();
            if (purchase != null)
            {
                purchasehistory.Purchaseid = purchase.purchaseId;
                purchasehistory.Buyerid = purchase.buyerId;
                 purchasehistory.Transactiontype = purchase.transactionType;
                 purchasehistory.Itemid = purchase.itemId;
                purchasehistory.Noofitems = purchase.noOfItems;
                purchasehistory.Datetime = purchase.dateTime;
                purchasehistory.Remarks = purchase.remarks;
                purchasehistory.Transactiontype = purchase.transactionStatus;
            }
            _buyerContext.Purchasehistory.Add(purchasehistory);
            var buyitem = await _buyerContext.SaveChangesAsync();
            if (buyitem > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

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

        public async Task<AddToCart> GetCartItem(string cartId)
        {
            Cart cart = await _buyerContext.Cart.FindAsync(cartId);
            if (cart == null)
                return null;
            else
            {
                AddToCart cart1 = new AddToCart();
                cart1.cartId = cart.Cartid;
                cart1.categoryId = cart.Categoryid;
                cart1.subCategoryId = cart.Subid;
                cart1.buyerId = cart.Buyerid;
                cart1.itemId = cart.Itemid;
                cart1.price = cart.Price;
                cart1.itemName = cart.Itemname;
                cart1.description = cart.Description;
                cart1.stockNo = cart.Stockno;
                cart1.remarks = cart.Remarks;
                cart1.imageName = cart.Imagename;
                return cart1;
            }
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

        public async Task<List<SubCategory>> GetSubCategories(ProductCategory productCategory)
        {
            if (productCategory == null)
            {
                return null;
            }
            else
            {
                return await _buyerContext.SubCategory.Where(e => e.Categoryid == productCategory.categoryId).ToListAsync();
            }
        }

     /*       public async Task<List<Items>> Items(string price, string price1)
        {

            throw new NotImplementedException();
        }*/

       /* public async Task<List<Purchasehistory>> Purchase((PurchaseHistory purchaseHistory)
        {
            Buyer buyer = _buyerContext.Buyer.Find(purchaseHistory.);
            if (buyer == null)
            {
                return null;
            }
            else
            {
                return await _buyerContext.Purchasehistory.Where(e => e.Buyerid== buyer.Buyerid).ToListAsync();
            }
        }*/

            public async Task<List<Items>> Search(Product product)
        {
            if (product == null)
            {
                return null;
            }
            else
            {
                return await _buyerContext.Items.Where(e => e.Itemname == product.productName).ToListAsync();
            }
        }

            public async Task<List<Items>> SearchItemByCategory(ProductCategory productCategory)
        {
            if (productCategory == null)
            {
                return null;
            }
            else
            {
                return await _buyerContext.Items.Where(e => e.Categoryid == productCategory.categoryId).ToListAsync();
            }
        }

            public async Task<List<Items>> SearchItemBySubCategory(ProductSubCategory productSubCategory)
        {
            if (productSubCategory == null)
            {
                return null;
            }
            else
            {
                return await _buyerContext.Items.Where(e => e.Subid== productSubCategory.subCategoryId).ToListAsync();
            }
        }
        }
}
