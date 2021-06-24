using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TheShop.Data;
using TheShop.Models;
using TheShop.Repositories;
using TheShop.Suppliers;

namespace TheShop.Tests
{
    [TestClass]
    public class ShopServiceTests
    {
        private IShopService _shopService;

        [TestInitialize]
        public void Initialize()
        {
            var _dbContext = new ShopContext();

            _shopService = new ShopService(
                new SalesHistoryRepository(_dbContext),
                new SupplierRepository(_dbContext),
                new Logger(new DebugLogger())
                );


            List<Article> Supllier1Articles = new List<Article>
            {
                new Article() { SupplierId = 10, Name = "Article1 from supplier1", Id = 1, Price = 458, InStock = 3 },
                new Article() { SupplierId = 10, Name = "Article2 from supplier1", Id = 2, Price = 100, InStock = 0 }
            };

            List<Article> Supllier2Articles = new List<Article>
            {
                new Article() { SupplierId = 11, Name = "Article1 from supplier2", Id = 1, Price = 459, InStock = 3 },
                new Article() { SupplierId = 11, Name = "Article2 from supplier2", Id = 2, Price = 200, InStock = 3 }
            };

            List<Article> Supllier3Articles = new List<Article>
            {
                new Article() { SupplierId = 12, Name = "Article1 from supplier3", Id = 1, Price = 460, InStock = 3 }
            };


            _shopService.RegisterNewSupplier(new Supplier { Id = 10, Name = "Supplier1", Articles = Supllier1Articles });
            _shopService.RegisterNewSupplier(new Supplier { Id = 11, Name = "Supplier2", Articles = Supllier2Articles });
            _shopService.RegisterNewSupplier(new Supplier { Id = 12, Name = "Supplier3", Articles = Supllier3Articles });
            //_dbContext.Suppliers.Add(new Supplier { Name = "Supplier1", Articles = Supllier1Articles });

        }

        [TestMethod]
        public void GetSoldArticleTest()
        {
            //Arrange
            var expectedValue = 1;
            _shopService.SellArticle(1, 999, 460);
            //Act
            var result = _shopService.GetSoldArticle(1);

            //Assert
            Assert.AreEqual(expectedValue, result.Id);
        }

        [TestMethod]
        public void SellArticleTest_NotFaund()
        {
            //Arrange
            var wrongId = -1;
            //Assert  
            Assert.ThrowsException<Exception>(() => _shopService.SellArticle(wrongId, 999, 103));
        }

        [TestMethod]
        public void SellArticleTest_OutOfStock()
        {
            //Arrange
            var expectedPrice = 100;
            var articleId = 2;
            var buyerId = 999;

            //Assert  
            Assert.ThrowsException<Exception>(() => _shopService.SellArticle(articleId, buyerId, expectedPrice));
        }

        [TestMethod]
        public void SellArticleTest_RemoveFromStock()
        {
            //Arrange
            var expectedPrice = 200;
            var articleId = 2;
            var buyerId = 999;
            var expectedValue = 2;

            _shopService.SellArticle(articleId, buyerId, expectedPrice);
            //Act
            var result = _shopService.OrderArticle(articleId, expectedPrice);

            //Assert
            Assert.AreEqual(expectedValue, result.InStock);
        }

        [TestMethod()]
        public void SellArticleTest_Success()
        {
            //Arrange
            var expectedValue = 2;
            _shopService.SellArticle(2, 999, 200);
            //Act
            var result = _shopService.GetSoldArticle(2);

            //Assert
            Assert.AreEqual(expectedValue, result.Id);
        }

        [TestMethod()]
        public void SellArticleTest_ExpectedPrice_Success()
        {
            //Arrange
            var expectedPrice = 459;
            var articleId = 1;
            var buyerId = 999;

            _shopService.SellArticle(articleId, buyerId, expectedPrice);
            //Act
            var result = _shopService.GetSoldArticle(articleId);

            //Assert
            Assert.IsTrue(expectedPrice >= result.Price);
        }

        [TestMethod()]
        public void SellArticleTest_ExpectedPrice_NotFound()
        {
            //Arrange
            var expectedPrice = 0;
            var articleId = 1;
            var buyerId = 999;

            //Assert
            Assert.ThrowsException<Exception>(() => _shopService.SellArticle(articleId, buyerId, expectedPrice));
        }
    }
}