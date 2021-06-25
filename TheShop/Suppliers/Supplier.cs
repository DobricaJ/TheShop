using System.Collections.Generic;
using TheShop.Models;

namespace TheShop.Suppliers
{
    public class Supplier : ISupplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Article> Articles { get; set; }
    }
}
