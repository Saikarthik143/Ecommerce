using BuyerDB.Entity;
using BuyerDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyerDB.Repositories;

namespace ItemService.Manager
{
    public class ItemManager : IItemManager
    {
        private readonly IItemRepository _iitemRepository;
        public ItemManager(IItemRepository iitemRepository)
        {
            _iitemRepository = iitemRepository;
        }
      

      /*  public async Task<List<Product>> SearchItemByCategory(ProductCategory productCategory)
        {
            List<Product> searchCategory = await _iitemRepository.SearchItemByCategory(productCategory);
            if (searchCategory != null)
            {
                return searchCategory;
            }
            else
            {
                return null;
            }
        }*/

       /* public async Task<List<Product>> SearchItemBySubCategory(ProductSubCategory productSubCategory)
        {
            List<Product> searchSubCategory = await _iitemRepository.SearchItemBySubCategory(productSubCategory);
            if (searchSubCategory != null)
            {
                return searchSubCategory;
            }
            else
            {
                return null;
            }
        }*/

        public async Task<bool> BuyItem(PurchaseHistory purchase)
        {
            bool buyitem = await _iitemRepository.BuyItem(purchase);
            if (buyitem)

                return true;
            else
                return false;
        }

        /* public async Task<List<ProductCategory>> GetCategories()
         {
             List<ProductCategory> category = await _iitemRepository.GetCategories();
             if (category != null)
             {
                 return category;
             }
             else
             {
                 return null;
             }
         }

         public async Task<List<ProductSubCategory>> GetSubCategories(ProductCategory productCategory)
         {
             List<ProductSubCategory> subCategory = await _iitemRepository.GetSubCategories(productCategory);
             if (subCategory != null)
             {
                 return subCategory;
             }
             else
             {
                 return null;
             }
         }*/
        public async Task<List<Product>> Items(int price, int price1)
        {
            List<Product> itemsprice = await _iitemRepository.Items(price, price1);
            if (itemsprice != null)
            {
                return itemsprice;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<PurchaseHistory>> Purchase(int buyerId)
        {
            List<PurchaseHistory> purchase = await _iitemRepository.Purchase(buyerId);
            if (purchase != null)
            {
                return purchase;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Product>> Search(string itemName)
        {
            List<Product> search = await _iitemRepository.Search(itemName);
            if (search != null)
            {
                return search;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AddToCart(AddToCart cart)
        {
            bool buyercart = await _iitemRepository.AddToCart(cart);
            if (buyercart)
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
            bool cart = await _iitemRepository.CheckCartItem(buyerId, itemId);
            if (cart)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<AddToCart>> GetCarts(int buyerId)
        {
            List<AddToCart> cart = await _iitemRepository.GetCarts(buyerId);
            if (cart != null)
            {
                return cart;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteCart(int cartId)
        {
            var deletecart = await _iitemRepository.DeleteCart(cartId);
            if (deletecart)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<AddToCart> GetCartItem(int cartid)
        {
            AddToCart cart = await _iitemRepository.GetCartItem(cartid);
            if (cart != null)
            {
                return cart;
            }
            else
            {
                return null;
            }

        }
        public async Task<int> GetCount(int buyerid)
        {
            var count = await _iitemRepository.GetCount(buyerid);
            if (count > 0)
            {
                return count;
            }
            else
                return 0;
        }

    }
}
