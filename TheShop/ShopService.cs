using System;
using TheShop.Models;
using TheShop.Repositories;
using TheShop.Suppliers;

namespace TheShop
{
    public class ShopService : IShopService
    {
        private readonly ISalesHistoryRepository _salesHistoryRepository;
        private readonly ISupplierRepository _supplierRepository;
        private ILogger _logger;

        public ShopService(
            ISalesHistoryRepository salesHistoryRepository,
            ISupplierRepository supplierRepository,
            ILogger logger)
        {
            _salesHistoryRepository = salesHistoryRepository;
            _supplierRepository = supplierRepository;
            _logger = logger;
        }

        public Article GetSoldArticle(int articleId)
        {
            _logger = new Logger(new InfoLogger());
            _logger.LogMessage($"Trying to get sold article with ArticleId = {articleId}");

            try
            {
                return _salesHistoryRepository.GetById(articleId);
            }
            catch (Exception ex)
            {
                string message = $"Could not get article with ArticleId = {articleId}";

                _logger.LogMessage(message);
                _logger = new Logger(new ErrorLogger());
                _logger.LogMessage(ex.Message);

                throw new Exception(message);
            }
        }

        public Article OrderArticle(int articleId, decimal maxExpectedPrice)
        {
            _logger = new Logger(new InfoLogger());
            _logger.LogMessage($"Trying to order article with ArticleId = {articleId} and MaxExpectedPrice = {maxExpectedPrice}");

            try
            {
                return _supplierRepository.GetArticle(articleId, maxExpectedPrice);
            }
            catch (Exception ex)
            {
                string message = $"Could not order article with ArticleId = {articleId} and MaxExpectedPrice = {maxExpectedPrice}";

                _logger.LogMessage(message);
                _logger = new Logger(new ErrorLogger());
                _logger.LogMessage(ex.Message);

                throw new Exception(message);
            }
        }

        public void RegisterNewSupplier(ISupplier supplier)
        {
            _supplierRepository.RegisterNewSupplier(supplier);
        }

        public void SellArticle(int articleId, int buyerId, decimal maxExpectedPrice)
        {

            _logger = new Logger(new InfoLogger());
            _logger.LogMessage($"Trying to Sell article with ArticleId = {articleId} and MaxExpectedPrice = {maxExpectedPrice}");

            var article = OrderArticle(articleId, maxExpectedPrice);

            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                _salesHistoryRepository.Save(article);
                _supplierRepository.RemoveFromStock(article);

                _logger.LogMessage($"The Article with ArticleId = {articleId} is successfully sold");
            }
            catch (ArgumentNullException ex)
            {
                string message = $"Could not Sell article with ArticleId = {articleId} and MaxExpectedPrice = {maxExpectedPrice}";

                _logger.LogMessage(message);
                _logger = new Logger(new ErrorLogger());
                _logger.LogMessage(ex.Message);

                throw new Exception(message);
            }
        }
    }
}
