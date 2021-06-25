using TheShop.Models;
using TheShop.Suppliers;

namespace TheShop.Repositories
{
    public interface ISupplierRepository
    {
        bool ArticleInInventory(int id);

        Article GetArticle(int id, decimal maxExpectedPrice);

        void RegisterNewSupplier(ISupplier supplier);

        void RemoveFromStock(Article article);
    }
}