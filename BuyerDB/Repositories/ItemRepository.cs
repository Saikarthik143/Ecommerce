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
        private readonly BuyerDBContext _buyerContext;
        public ItemRepository(BuyerDBContext buyerContext)
        {
            _buyerContext = buyerContext;
        }
        public async Task<bool> AddToCart(AddToCart cart)
        {
            Cart cart1 = new Cart();
            if (cart != null)
            {
                cart1.Cartid = cart.cartId;
                //cart1. = cart.categoryId;
                //cart1.Subid = cart.subCategoryId;
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

        public async Task<bool> CheckCartItem(int buyerId,int itemId)
        {
            Cart cart = await _buyerContext.Cart.SingleOrDefaultAsync(e => e.Buyerid == buyerId && e.Itemid == itemId);
            if (cart != null)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteCart(int cartId)
        {
            Cart cart = await _buyerContext.Cart.FindAsync(cartId);
            if (cart != null)
            {
                _buyerContext.Cart.Remove(cart);
                await _buyerContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<AddToCart> GetCartItem(int cartId)
        {
            Cart cart = await _buyerContext.Cart.FindAsync(cartId);
            if (cart == null)
                return null;
            else
            {
                AddToCart cart1 = new AddToCart();
                cart1.cartId = cart.Cartid;
              //  cart1.categoryId = cart.Categoryid;
              //  cart1.subCategoryId = cart.Subid;
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

        public async Task<List<AddToCart>> GetCarts(int buyerId)
        {

            List<Cart> cart = await _buyerContext.Cart.Where(e => e.Buyerid == buyerId).ToListAsync();
            if (cart == null)
                return null;
            else
            {
                List<AddToCart> cart1 = cart.Select(s => new AddToCart
                {
                    cartId = s.Cartid,
                   // categoryId = s.Categoryid,
                   // subCategoryId = s.Subid,
                    buyerId = s.Buyerid,
                    itemId = s.Itemid,
                    price = s.Price,
                    itemName = s.Itemname,
                    description = s.Description,
                    stockNo = s.Stockno,
                    remarks = s.Remarks,
                    imageName = s.Imagename,
                }).ToList();
                return cart1;
            }
        }


       /* public async Task<List<ProductCategory>> GetCategories()
        {
            List<Category> categories = await _buyerContext.Category.ToListAsync();
            if (categories == null)
            {
                return null;
            }
            else
            {
                List<ProductCategory> products = categories.Select(s => new ProductCategory
                {
                    categoryId = s.Categoryid,
                    categoryName = s.Categoryname,
                    categoryDetails = s.Categorydetails,
                }).ToList();
                return products;
            }
        }*/

        public async Task<int> GetCount(int buyerId)
        {
            var count = await _buyerContext.Cart.Where(e => e.Buyerid == buyerId).ToListAsync();
            if (count != null)
            {
                int count1 = count.Count();
                return count1;
            }
            else
            {
                return 0;
            }
        }

        public async Task<List<Items>> GetItems()
        {
            return await _buyerContext.Items.ToListAsync();
        }

        /*public async Task<List<ProductSubCategory>> GetSubCategories(ProductCategory productCategory)
        {
            List<SubCategory> items = await _buyerContext.SubCategory.Where(e => e.Categoryid == productCategory.categoryId).ToListAsync();
            if (items == null)
            {
                return null;
            }
            else
            {
                List<ProductSubCategory> products = items.Select(s => new ProductSubCategory
                {
                    subCategoryName = s.Subname,
                    categoryId = s.Categoryid,
                    subCategoryId = s.Subid,

                    gst = s.Gst,
                    subCategoryDetails = s.Subdetails,
                }).ToList();
                return products;
            }
        }*/

        

        /*  public async Task<List<Purchasehistory>> Purchase((PurchaseHistory purchaseHistory)
          {
              Buyer buyer = _buyerContext.Buyer.Find(purchaseHistory.);
              if (buyer == null)
              {
                  return null;
              }
              else
              {
                  return await _buyerContext.Purchasehistory.Where(e => e.Buyerid == buyer.Buyerid).ToListAsync();
              }
          }*/
        public async Task<List<Product>> Items(int price, int price1)
        {
            List<Items> items = await _buyerContext.Items.Where(e => e.Price >= price && e.Price <= price1).ToListAsync();
            if (items == null)
            {
                return null;
            }
            else
            {
                List<Product> products = items.Select(s => new Product
                {
                    productId = s.Itemid,
                    productName = s.Itemname,
                    price = s.Price,
                    description = s.Description,
                    stockno = s.Stockno,
                    remarks = s.Remarks,
                    imageName = s.Imagename,
                }).ToList();
                return products;
            }
        }
        public async Task<List<PurchaseHistory>> Purchase(int buyerId)
        {
            Buyer buyer = _buyerContext.Buyer.Find(buyerId);
            if (buyer == null)
            {
                return null;
            }
            else
            {
                List<Purchasehistory> purchasehistories = await _buyerContext.Purchasehistory.Where(e => e.Buyerid == buyer.Buyerid).ToListAsync();
                if (purchasehistories == null)
                {
                    return null;
                }
                else
                {
                    List<PurchaseHistory> purchaseHistories = purchasehistories.Select(s => new PurchaseHistory
                    {
                        purchaseId = s.Purchaseid,
                        buyerId = s.Buyerid,
                        transactionType = s.Transactiontype,
                        itemId = s.Itemid,
                        noOfItems = s.Noofitems,
                        dateTime = s.Datetime,
                        remarks = s.Remarks,
                        transactionStatus = s.Transactionstatus,
                    }).ToList();
                    return purchaseHistories;
                }
            }
        }
        public async Task<List<Product>> Search(string itemName)
        {
            List<Items> items = await _buyerContext.Items.Where(e => e.Itemname == itemName).ToListAsync();
            if (items == null)
            {
                return null;
            }
            else
            {
                List<Product> products = items.Select(s => new Product
                {
                    productId = s.Itemid,
                    productName = s.Itemname,
                    price = s.Price,
                    description = s.Description,
                    stockno = s.Stockno,
                    remarks = s.Remarks,
                    imageName = s.Imagename,
                }).ToList();
                return products;
            }
        }
       
       /* public async Task<List<Product>> SearchItemByCategory(ProductCategory productCategory)
        {
            List<Items> items = await _buyerContext.Items.Where(e => e.Categoryid == productCategory.categoryId).ToListAsync();
            if (items == null)
            {
                return null;
            }
            else
            {
                List<Product> products = items.Select(s => new Product
                {
                    productId = s.Itemid,
                    productName = s.Itemname,
                    categoryId = s.Categoryid,
                    subCategoryId = s.Subid,
                    //   categoryName = s.Categoryname,
                    // subCategoryName = s.Subcategoryname,
                    price = s.Price,
                    description = s.Description,
                    stockno = s.Stockno,
                    remarks = s.Remarks,
                    // imageName = s.Imagename,
                }).ToList();
                return products;
            }
        }
*/
       /* public async Task<List<Product>> SearchItemBySubCategory(ProductSubCategory productSubCategory)
        {
            List<Items> items = await _buyerContext.Items.Where(e => e.Subid == productSubCategory.subCategoryId).ToListAsync();
            if (items == null)
            {
                return null;
            }
            else
            {
                List<Product> products = items.Select(s => new Product
                {
                    productId = s.Itemid,
                    productName = s.Itemname,
                    categoryId = s.Categoryid,
                    subCategoryId = s.Subid,
                    //   categoryName = s.Categoryname,
                    //  subCategoryName = s.Subcategoryname,
                    price = s.Price,
                    description = s.Description,
                    stockno = s.Stockno,
                    remarks = s.Remarks,
                    // imageName = s.Imagename,
                }).ToList();
                return products;
            }
        }*/
    }
}
