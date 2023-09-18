using ECommerceAPI.Data;
using ECommerceAPI.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : Controller
	{
		private readonly ECommerceDbContext dbContext;

		public ProductsController(ECommerceDbContext dbContext) {
			this.dbContext = dbContext;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll() 
		{
			var products = await dbContext.Products.ToListAsync();

			return Ok(products);
		}
	}
}
