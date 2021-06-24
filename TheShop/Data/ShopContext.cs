﻿using System.Collections.Generic;
using System.Data.Entity;
using TheShop.Models;
using TheShop.Suppliers;

namespace TheShop.Data
{
    public class ShopContext
    {
        public ShopContext()
        {
            SoldArticles = new List<Article>();
            Suppliers = new List<ISupplier>();
        }

        public List<Article> SoldArticles { get; set; }

        public List<ISupplier> Suppliers { get; set; }
    }
}
