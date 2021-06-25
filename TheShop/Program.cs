using Autofac;
using System;
using TheShop.Data;
using TheShop.Repositories;

namespace TheShop
{
    // Main cases are covered in tests, so this class can be removed during refactoring. I leave this only as an example of using ShopService and dependencies.

    internal class Program
    {
        private static void Main(string[] args)
        {

            var shopService = GetShopService();

            try
            {
                //order and sell
                shopService.SellArticle(1, 20, 10);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                //print article on console
                var article = shopService.GetSoldArticle(1);
                Console.WriteLine("Found article with ID: " + article.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Article not found: " + ex);
            }

            try
            {
                //print article on console				
                var article = shopService.GetSoldArticle(12);
                Console.WriteLine("Found article with ID: " + article.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Article not found: " + ex);
            }

            Container.Dispose();

            Console.ReadKey();
        }

        public static IContainer Container { get; private set; }

        /// <summary>
        ///  Dependency injection using Autofac library
        /// </summary>
        /// <returns> Instance of ShopService</returns>
        public static IShopService GetShopService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>();
            builder.RegisterType<SalesHistoryRepository>().As<ISalesHistoryRepository>();
            builder.RegisterType<ShopContext>().As<ShopContext>();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<InfoLogger>().As<ILogger>();
            builder.RegisterType<ShopService>().As<IShopService>();
            Container = builder.Build();

            return Container.Resolve<IShopService>();
        }
    }
}