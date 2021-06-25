using System.Collections.Generic;
using System.Data.Entity;
using TheShop.Models;
using TheShop.Suppliers;

namespace TheShop.Data
{
    /// <summary>
    /// This is the only exemple, how could be DB storage.
    /// </summary>
    public class AppContext : DbContext
    {
        public AppContext(): base("connection string")
        {
        }

        public DbSet<Article> SoldArticles { get; set; }

        public DbSet<ISupplier> Suppliers { get; set; }
    }
}
