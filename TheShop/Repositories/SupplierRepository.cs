using System.Linq;
using TheShop.Data;
using TheShop.Models;
using TheShop.Suppliers;

namespace TheShop.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ShopContext db) : base(db)
        {
        }

        public bool ArticleInInventory(int id)
        {
            return _db.Suppliers.SelectMany(x => x.Articles).Any(a => a.Id == id);
        }

        public Article GetArticle(int id, decimal maxExpectedPrice)
        {
            return _db.Suppliers
                .SelectMany(x => x.Articles)
                .First(a => a.Id == id 
                && a.Price <= maxExpectedPrice
                && a.InStock > 0);
        }

        public void RegisterNewSupplier(ISupplier supplier)
        {
            _db.Suppliers.Add(supplier);
        }

        public void RemoveFromStock(Article article)
        {
            _db.Suppliers.First(x => x.Id == article.SupplierId).Articles.First(a => a.Id == article.Id).InStock --;
        }
    }
}