using ShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
	public class AdvertisementDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public string Brand { get; set; }
		public int CategoryId { get; set; }
		public string? CategoryName { get; set; }
		public int Views { get; set; }
		public DateTime PublicationDate { get; set; }
		public int ConditionId { get; set; }
		public string? ConditionName { get; set; }
		public string? SellerId { get; set; }
		public string? SellerName { get; set; }
		public string ImageUrl { get; set; }
		public string? LocationName { get; set; }
		public int? LocationId { get; set; }
	}
}
