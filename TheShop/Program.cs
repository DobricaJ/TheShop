using System;
using TheShop.Data;
using TheShop.Repositories;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{


			//var container = new StructureMap.Container(x =>
			//{
			//	x.For<ISupplierRepository>().Use<SupplierRepository>().Singleton();
			//	x.For<ISalesHistoryRepository>().Use<SalesHistoryRepository>().Singleton();
			//	//x.For<Logger>().Use<Logger>().Singleton();

			//});

			//var shopService = container.GetInstance<ShopService>();


			//container.Release(shopService);

			var _context = new ShopContext();

			var shopService = new ShopService(
				new SalesHistoryRepository(_context),
				new SupplierRepository(_context),
				new Logger(new DebugLogger())
				);


			try
			{
				//order and sell
				//shopService.OrderAndSellArticle(1, 20, 10);
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

			Console.ReadKey();
		}


	}
}