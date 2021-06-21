using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Data;
using TheShop.Models;
using TheShop.Suppliers;

namespace TheShop
{
	public class ShopService : IShopService
	{
		private readonly DatabaseDriver _dbContext;
		private readonly Logger logger;

		private readonly SupplierRegister _suppliers;

		private Article article = null;

        public ShopService(SupplierRegister supplierRegister, DatabaseDriver dbContext)
		{
			_suppliers = supplierRegister;
			_dbContext = dbContext;
		}

		public Article GetById(int id)
		{
			return _dbContext.GetById(id);
		}

		public Article OrderArticle(int id, int maxExpectedPrice)
		{

			var s = _suppliers.Suppliers.FirstOrDefault(x => x.GetArticle(id).Price <= maxExpectedPrice);

			article = s.GetArticle(id);

			if (article == null)
			{
				throw new Exception("Could not order article");
			}

			return article;
		}

		public void SellArticle(Article article, int buyerId)
		{
			logger.Debug("Trying to sell article with id=" + article.Id);

			article.IsSold = true;
			article.SoldDate = DateTime.Now;
			article.BuyerUserId = buyerId;

			try
			{
				_dbContext.Save(article);
				logger.Info("Article with id=" + article.Id + " is sold.");
			}
			catch (ArgumentNullException ex)
			{
				logger.Error("Could not save article with id=" + article.Id);
				throw new Exception("Could not save article with id");
			}
			catch (Exception)
			{
			}
		}
    }
}
