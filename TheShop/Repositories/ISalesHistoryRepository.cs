using TheShop.Models;

namespace TheShop.Repositories
{
    public interface ISalesHistoryRepository
    {
        Article GetById(int id);

        void Save(Article article);
    }
}