using BuyerDB.Entity;
using BuyerDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyerDB.Repositories;

namespace ItemService.Manager
{
    public class ItemManager:IItemManager
    {
        private readonly IItemRepository _itemRepository;
        public ItemManager(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<List<Items>> Search(Product product)
        {
            List<Items> search = await _itemRepository.Search(product);
            if (search != null)
            {
                return search;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Items>> SearchItemByCategory(ProductCategory productCategory)
        {
            List<Items> searchCategory = await _itemRepository.SearchItemByCategory(productCategory);
            if (searchCategory != null)
            {
                return searchCategory;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Items>> SearchItemBySubCategory(ProductSubCategory productSubCategory)
        {
            List<Items> searchSubCategory = await _itemRepository.SearchItemBySubCategory(productSubCategory);
            if (searchSubCategory != null)
            {
                return searchSubCategory;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> BuyItem(PurchaseHistory purchase)
        {
             bool buyitem = await _itemRepository.BuyItem(purchase);
            if (buyitem)

                return true;
            else
                return false;
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> category = await _itemRepository.GetCategories();
            if (category != null)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<SubCategory>> GetSubCategories(ProductCategory productCategory)
        {
            List<SubCategory> subCategory = await _itemRepository.GetSubCategories(productCategory);
            if (subCategory != null)
            {
                return subCategory;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AddToCart(AddToCart cart)
        {
            bool buyercart = await _itemRepository.AddToCart(cart);
            if (buyercart)
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
            bool cart = await _itemRepository.CheckCartItem(buyerId, itemId);
            if (cart)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Cart>> GetCarts(string buyerId)
        {
            List<Cart> cart = await _itemRepository.GetCarts(buyerId);
            if (cart != null)
            {
                return cart;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteCart(string cartId)
        {
            var deletecart = await _itemRepository.DeleteCart(cartId);
            if (deletecart)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<AddToCart> GetCartItem(string cartid)
        {
            AddToCart cart = await _itemRepository.GetCartItem(cartid);
            if (cart != null)
            {
                return cart;
            }
            else
            {
                return null;
            }
            
        }

    }
}
