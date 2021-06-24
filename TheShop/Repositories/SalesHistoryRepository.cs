using System.Linq;
using TheShop.Data;
using TheShop.Models;

namespace TheShop.Repositories
{
    public class SalesHistoryRepository : BaseRepository<Article>, ISalesHistoryRepository
    {
        public SalesHistoryRepository(ShopContext db) : base(db)
        {
        }

        public Article GetById(int id)
        {
            return _db.SoldArticles.FirstOrDefault(a => a.Id == id);
        }

        public void Save(Article article)
        {
            _db.SoldArticles.Add(article);
        }

    }
}