using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyerDB.Models;
using ItemService.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IItemManager _iitemManager;
        public ItemController(IItemManager iitemManager)
        {
            _iitemManager = iitemManager;
        }
        /// <summary>
        /// Add to cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddtoCart")]
        public async Task<IActionResult> AddToCart(AddToCart cart)
        {
            bool cart1 = await _iitemManager.AddToCart(cart);
            if (cart1)
                return Ok();
            else
                return Ok("Item not added");
        }
        /// <summary>
        /// Buying item
        /// </summary>
        /// <param name="purchasehistory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("BuyItem")]
        public async Task<IActionResult> BuyItem(PurchaseHistory purchasehistory)
        {
            return Ok(await _iitemManager.BuyItem(purchasehistory));
        }
        /// <summary>
        /// Check cart item
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckCartItem/{buyerId}/{itemId}")]
        public async Task<IActionResult> CheckCartItem(string buyerId, string itemId)
        {
            return Ok(await _iitemManager.CheckCartItem(buyerId, itemId));
        }
        /// <summary>
        /// Delete Cart Item
        /// </summary>
        /// <param name="cartid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCart/{cartid}")]
        public async Task<IActionResult> DeleteCart(string cartid)
        {
            return Ok(await _iitemManager.DeleteCart(cartid));
        }
        /// <summary>
        /// Get Cart Item
        /// </summary>
        /// <param name="cartid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCartItem/{cartid}")]
        public async Task<IActionResult> GetCartItem(string cartid)
        {
            AddToCart cart1 = await _iitemManager.GetCartItem(cartid);
            if (cart1 != null)
            {
                return Ok(cart1);
            }
            else
            {
                return Ok("Cart is Null");
            }
        }
        /// <summary>
        /// Get Cart Itm
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCart/{buerId}")]
        public async Task<IActionResult> GetCart(string buyerId)
        {
            return Ok(await _iitemManager.GetCarts(buyerId));
        }
        /// <summary>
        /// GetCategory of items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            return Ok(await _iitemManager.GetCategories());
        }
       
        /// <summary>
        /// Get SubCategory
        /// </summary>
        /// <param name="productCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetSubCategory")]
        public async Task<IActionResult> SubCategory(ProductCategory productCategory)
        {
            if (productCategory is null)
            {
                return BadRequest();
            }
            return Ok(await _iitemManager.GetSubCategories(productCategory));
        }
       
       
       
        /// <summary>
        /// Search items
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SearchItems")]
        public async Task<IActionResult> SearchItem(Product product)
        {

            return Ok(await _iitemManager.Search(product));
        }
        /// <summary>
        /// search items using category
        /// </summary>
        /// <param name="productCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SearchItemByCategory")]
        public async Task<IActionResult> SearchItemByCategory(ProductCategory productCategory)
        {
            return Ok(await _iitemManager.SearchItemByCategory(productCategory));
        }
        /// <summary>
        /// Search items using Subcategory
        /// </summary>
        /// <param name="productSubCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SearchItemBySubCategory")]
        public async Task<IActionResult> SearchItemBySubCategory(ProductSubCategory productSubCategory)
        {

            return Ok(await _iitemManager.SearchItemBySubCategory(productSubCategory));

        }
    }
}