using System.Collections.Generic;

namespace TheShop.Suppliers
{
    public class SupplierRegister
    {
        public HashSet<ISupplier> Suppliers { get; }

        SupplierRegister()
        {
            Suppliers.Add(new Supplier1());
            Suppliers.Add(new Supplier2());
            Suppliers.Add(new Supplier3());
        }
    }
}
