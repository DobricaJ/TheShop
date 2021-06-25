using TheShop.Models;
using TheShop.Suppliers;

namespace TheShop
{
    public interface IShopService
    {
        Article GetSoldArticle(int articleId);

        Article OrderArticle(int articleId, decimal maxExpectedPrice);

        void SellArticle(int articleId, int buyerId, decimal maxExpectedPrice);

        void RegisterNewSupplier(ISupplier supplier);
    }
}