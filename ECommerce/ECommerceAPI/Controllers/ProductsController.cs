using AutoMapper;
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
		private readonly IMapper mapper;

		public ProductsController(ECommerceDbContext dbContext, IMapper mapper) {
			this.dbContext = dbContext;
			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync() 
		{
			var products = await dbContext.Products.ToListAsync();

			return Ok(products);
		}

		[HttpGet]
		[Route("{ID:Guid}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] Guid ID) {
			var domainProduct = await dbContext.Products.FirstOrDefaultAsync(o => o.ID == ID);
			if (domainProduct == null)
			{
				return NotFound("Product does not exist");
			}
			return Ok(mapper.Map<ProductDTO>(domainProduct));
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] AddProductDTO addProductDTO) 
		{
			var domainProduct = mapper.Map<Product>(addProductDTO);
			var createProduct = await dbContext.Products.AddAsync(domainProduct);
			if (createProduct == null)
			{
				return BadRequest();
			}
			await dbContext.SaveChangesAsync();
			return Ok(mapper.Map<ProductDTO>(domainProduct));
		}

		[HttpPut]
		[Route("{ID:Guid}")]
		public async Task<IActionResult> UpdateByIdAsync(Guid ID, UpdateProductDTO updateProductDTO) {
			var existingProduct = await dbContext.Products.FirstOrDefaultAsync(o => o.ID == ID);
			if (existingProduct == null)
			{
				return NotFound("Cannot Update, Product does not exist");
			}
			existingProduct.Name = updateProductDTO.Name;
			existingProduct.Url = updateProductDTO.Url;
			existingProduct.ImageUrl = updateProductDTO.ImageUrl;
			existingProduct.Company = updateProductDTO.Company;
			existingProduct.Quantity = updateProductDTO.Quantity;
			existingProduct.Price = updateProductDTO.Price;
			existingProduct.Sale = updateProductDTO.Sale;

			await dbContext.SaveChangesAsync();
			return Ok(mapper.Map<UpdateProductDTO>(existingProduct));
		}
	}
}
