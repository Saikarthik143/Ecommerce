using BuyerDB.Entity;
using BuyerDB.Models;
using BuyerDB.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestItemService
{
    [TestFixture]
    class TestItemRepository
    {
        IItemRepository iitemRepository;
        DbContextOptionsBuilder<BuyerDBContext> _builder;
        [SetUp]
        public void SetUp()
        {
            _builder = new DbContextOptionsBuilder<BuyerDBContext>().EnableSensitiveDataLogging().UseInMemoryDatabase(Guid.NewGuid().ToString());
            BuyerDBContext db = new BuyerDBContext(_builder.Options);
            iitemRepository = new ItemRepository(db);
        }
        [TearDown]
        public void TearDown()
        {
            iitemRepository = null;
        }
        /// <summary>
        /// Add to cart
        /// </summary>
        /// <returns></returns>
        [Test]
        [TestCase(123, 856, 401, 1235, 662, 50, "atta", "flour", "342", "good", "atta.img")]
        [Description("Add to cart testing")]
        public async Task AddToCart_Successfull(int cartId,int buyerId, int itemid,int price, string itemName, string description, int stockno, string remarks, string imageName)
        {
            try
            {
                var cart = new AddToCart { cartId = cartId,  buyerId = buyerId, itemId = itemid, price = price, itemName = itemName, description = description, stockNo = stockno, remarks = remarks, imageName = imageName };
                var result = await iitemRepository.AddToCart(cart);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// buy item
        /// </summary>
        /// <returns></returns>
        [Test]
        [TestCase(5232, 1235, 662, "debit", 2, "good quality", "paid")]
        [Description("Buy item sucessfull")]
        public async Task BuyItem_Sucessfull(int purchaseId, int buyerId,int itemId, string transactionType, int noofitems, string remarks, string transactionStatus)
        {
            try
            {
                DateTime dateTime = System.DateTime.Now;
                var purchaseHistory = new PurchaseHistory { purchaseId = purchaseId, buyerId = buyerId, itemId = itemId, transactionType = transactionType, noOfItems = noofitems, remarks = remarks, transactionStatus = transactionStatus, dateTime = dateTime };
                var result = await iitemRepository.BuyItem(purchaseHistory);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// check cart
        /// </summary>
        /// <param name="buyerid"></param>
        /// <param name="itemid"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1235, 662)]
        [Description("Buy item unsuccess")]
        public async Task CheckCartItem_Sucessfull(int buyerid,int itemid)
        {
            try
            {
                var result = await iitemRepository.CheckCartItem(buyerid, itemid);
                Assert.True(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// check cart
        /// </summary>
        /// <param name="buyerid"></param>
        /// <param name="itemid"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1232, 532)]
        [Description("Check cart by cart buyerid")]
        public async Task CheckCartItem_UnSucessfull(int buyerid, int itemid)
        {
            try
            {
                var result = await iitemRepository.CheckCartItem(buyerid, itemid);
                Assert.False(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// delete cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(123)]
        [Description("Delete cart Successful")]
        public async Task DeleteCart_Sucessfull(int cartId)
        {
            try
            {
                var result = await iitemRepository.DeleteCart(cartId);
                Assert.True(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// delete cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(12)]
        [Description("Delete cart Unsucessful")]
        public async Task DeleteCart_UnSucessfull(int cartId)
        {
            try
            {
                var result = await iitemRepository.DeleteCart(cartId);
                Assert.False(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// get cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(123)]
        [Description("testing cart item")]
        public async Task GetCart_Successfull(int cartId)
        {
            try
            {
                var result = await iitemRepository.GetCartItem(cartId);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// get cart failure
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(124)]
        [Description("testing cart item")]
        public async Task GetCart_UnSuccessfull(int cartId)
        {
            try
            {
                var result = await iitemRepository.GetCartItem(cartId);
                Assert.IsNull(result, "Not found");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// get buyer cart
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1235)]
        [Description("testing buyer cart item")]
        public async Task GetBuyerCart_Successfull(int buyerId)
        {
            try
            {
                var result = await iitemRepository.GetCarts(buyerId);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// get buyer cart
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1234)]
        [Description("testing buyer cart item")]
        public async Task GetBuyerCart_UnSuccessfull(int buyerId)
        {
            try
            {
                var result = await iitemRepository.GetCarts(buyerId);
                Assert.IsEmpty(result, "No Items");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns></returns>
       /* [Test]
        [Description("testing categories")]
        public async Task GetCategories_Successfull()
        {
            try
            {
                var result = await iitemRepository.GetCategories();
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }*/
        /// <summary>
        /// get cart count
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1235)]
        [Description("testing buyer cart item")]
        public async Task GetCartCount_Successfull(int buyerId)
        {
            try
            {
                var result = await iitemRepository.GetCount(buyerId);
                Assert.NotZero(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// get cart count unsuccessfull
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1234)]
        [Description("testing buyer cart item")]
        public async Task GetCartCount_UnSuccessfull(int buyerId)
        {
            try
            {
                var result = await iitemRepository.GetCount(buyerId);
                Assert.Zero(result, "No cart items");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// get subcategories
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
       /* [Test]
        [TestCase("fruits vegetables")]
        [Description("testing getsubcategories")]
        public async Task GetSubCategories_Successfull(string categoryName)
        {
            try
            {
                ProductCategory productCategory = new ProductCategory { categoryName = categoryName };
                var result = await iitemRepository.GetSubCategories(productCategory);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase("fruits")]
        [Description("testing getsubcategories")]
        public async Task GetSubCategories_UnSuccessfull(string categoryName)
        {
            try
            {
                ProductCategory productCategory = new ProductCategory { categoryName = categoryName };
                var result = await iitemRepository.GetSubCategories(productCategory);
                Assert.IsEmpty(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
*/        /// <summary>
        /// sort items by price
        /// </summary>
        /// <param name="price"></param>
        /// <param name="price1"></param>
        /// <returns></returns>
        [Test]
        [TestCase(30, 100)]
        [Description("testing items in range ")]
        public async Task GetItems_Successfull(int price, int price1)
        {
            try
            {
                var result = await iitemRepository.Items(price, price1);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// purchase history
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1235)]
        [Description("testing purchase history")]
        public async Task PurchaseHistory_Successfull(int buyerId)
        {
            try
            {
                PurchaseHistory purchase = new PurchaseHistory { buyerId = buyerId };
                var result = await iitemRepository.Purchase(buyerId);
                Assert.IsNotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase(1234)]
        [Description("testing purchasehistory")]
        public async Task PurchaseHistory_UnSuccessfull(int buyerId)
        {
            try
            {
                PurchaseHistory purchase = new PurchaseHistory { buyerId = buyerId };
                var result = await iitemRepository.Purchase(buyerId);
                Assert.IsEmpty(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// search items
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        [Test]
        [TestCase("milk")]
        [Description("testing search items")]
        public async Task SearchItems_Successfull(string itemName)
        {
            try
            {
                Product product = new Product { productName = itemName };
                var result = await iitemRepository.Search(itemName);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase("choco")]
        [Description("testing search items")]
        public async Task SearchItems_UnSuccessfull(string itemName)
        {
            try
            {
                Product product = new Product { productName = itemName };
                var result = await iitemRepository.Search(itemName);
                Assert.IsEmpty(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// search items by category
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        /*[Test]
        [TestCase("fruits vegetables")]
        [Description("testing search items")]
        public async Task SearchItemsByCategory_Successfull(string itemName)
        {
            try
            {
                ProductCategory product = new ProductCategory { categoryName = itemName };
                var result = await iitemRepository.SearchItemByCategory(product);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase("choco")]
        [Description("testing search items")]
        public async Task SearchItemsByCategory_UnSuccessfull(string itemName)
        {
            try
            {
                ProductCategory product = new ProductCategory { categoryName = itemName };
                var result = await iitemRepository.SearchItemByCategory(product);
                Assert.IsEmpty(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }*/
        /// <summary>
        /// search items by subcategory
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
       /* [Test]
        [TestCase("fruits")]
        [Description("testing search items")]
        public async Task SearchItemsBySubCategory_Successfull(string itemName)
        {
            try
            {
                ProductSubCategory product = new ProductSubCategory { subCategoryName = itemName };
                var result = await iitemRepository.SearchItemBySubCategory(product);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase("choco")]
        [Description("testing search items")]
        public async Task SearchItemsSubCategory_UnSuccessfull(string itemName)
        {
            try
            {
                ProductSubCategory product = new ProductSubCategory { subCategoryName = itemName };
                var result = await iitemRepository.SearchItemBySubCategory(product);
                Assert.IsEmpty(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }*/
    }
}


