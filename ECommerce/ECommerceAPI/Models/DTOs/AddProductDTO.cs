﻿namespace ECommerceAPI.Models.Domains
{
	public class AddProductDTO
	{
        public string Name { get; set; }

		public string? Url { get; set; }

		public string? ImageUrl { get; set; }

		public string Company { get; set; }

		public int Quantity { get; set; }

		public double Price { get; set; }

		public int Sale { get; set; } = 0;
	}
}
