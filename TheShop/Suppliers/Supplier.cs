using System.Collections.Generic;
using System.Linq;
using TheShop.Models;

namespace TheShop.Suppliers
{
    public interface ISupplier
    {
        bool ArticleInInventory(int id);

        Article GetArticle(int id);

    }
    public class Supplier1 : ISupplier
    {

        public List<Article> articles = new List<Article> { 
            new Article { Id = 1, Name = "Article from supplier1", Price = 458 } };

        public bool ArticleInInventory(int id)
        {
            return articles.Exists(x => x.Id == id);
        }

        public Article GetArticle(int id)
        {
            return articles.First(x => x.Id == id);
        }
    }

    public class Supplier2 : ISupplier
    {

        private List<Article> articles = new List<Article> {
            new Article { Id = 1, Name = "Article from supplier2", Price = 459 } };

        public bool ArticleInInventory(int id)
        {
            return articles.Exists(x => x.Id == id);
        }

        public Article GetArticle(int id)
        {
            return articles.First(x => x.Id == id);
        }
    }

    public class Supplier3 : ISupplier
    {

        private List<Article> articles = new List<Article> {
            new Article { Id = 1, Name = "Article from supplier3", Price = 460 } };

        public bool ArticleInInventory(int id)
        {
            return articles.Exists(x => x.Id == id);
        }

        public Article GetArticle(int id)
        {
            return articles.First(x => x.Id == id);
        }
    }
}
