using ECommerceAPI.Models.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Data
{
	public class ECommerceDbContext: IdentityDbContext
	{
		public ECommerceDbContext(DbContextOptions<ECommerceDbContext> dbContextOptions) : base(dbContextOptions) { 
		
		}

		private DbSet<Product> Products { get; set; }

		private DbSet<Basket> Baskets { get; set; }
	}
}
