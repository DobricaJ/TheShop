using TheShop.Repositories;

namespace TheShop.Data
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ShopContext _db;

        public BaseRepository(ShopContext db) => _db = db;

        // There could be implementation of Generic insert, delete, update methods.
    }
}