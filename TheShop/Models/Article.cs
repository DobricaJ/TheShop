using System;

namespace TheShop.Models
{
    public class Article
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public int InStock { get; set; }

		public DateTime SoldDate { get; set; }

		public int SupplierId { get; set; }

		public int BuyerUserId { get; set; }
	}
}
