using TheShop.Models;

namespace TheShop
{
    interface IShopService
    {
        Article GetById(int id);

        Article OrderArticle(int id, int maxExpectedPrice);

        void SellArticle(Article article, int buyerId);
    }
}