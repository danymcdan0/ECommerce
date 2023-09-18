﻿namespace ECommerceAPI.Models.Domains
{
	public class Basket
	{
		public Guid OwnerID { get; set; }

		public Guid ID { get; set; }

		public List<ProductDTO>? Products { get; set; }
    }
}
