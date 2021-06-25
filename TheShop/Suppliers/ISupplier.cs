using System.Collections.Generic;
using TheShop.Models;

namespace TheShop.Suppliers
{
    public interface ISupplier
    {
        int Id { get; set; }

        string Name { get; set; }

        List<Article> Articles { get; set; }

    }
}
