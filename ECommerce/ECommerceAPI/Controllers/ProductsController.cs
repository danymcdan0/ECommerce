using AutoMapper;
using ECommerceAPI.Data;
using ECommerceAPI.Models.Domains;
using ECommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : Controller
	{
		private readonly IProductsRepository repository;

		public ProductsController(IProductsRepository repository) {
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync() 
		{
			var products = await repository.GetAllAsync();
			if (products != null)
			{
				return Ok(products);
			}
			else
			{
				return NotFound("ERROR: No products exist");
			}
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id) {
			var domainProduct = await repository.GetByIdAsync(id);
			if (domainProduct == null)
			{
				return NotFound("ERROR: Product does not exist");
			}
			return Ok(domainProduct);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] AddProductDTO addProductDTO) 
		{
			var createProduct = await repository.CreateAsync(addProductDTO);
			if (createProduct == null)
			{
				return BadRequest();
			}
			return Ok(createProduct);
		}

		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> UpdateByIdAsync(Guid id, UpdateProductDTO updateProductDTO) {
			var updateProduct = await repository.UpdateByIdAsync(id, updateProductDTO);
			if (updateProduct == null)
			{
				return NotFound("ERROR: Product does not exist");
			}
			return Ok(updateProduct);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> DeleteByIdAsync(Guid id) {
			var existingProduct = await repository.DeleteByIdAsync(id);
			if (existingProduct == null)
			{
				return NotFound("ERROR: Product does not exist");
			}
			return Ok(existingProduct);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAllAsync()
		{
			var products = await repository.DeleteAllAsync();
			return Ok(products);
		}
	}
}
