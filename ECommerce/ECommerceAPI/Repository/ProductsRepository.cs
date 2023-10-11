using AutoMapper;
using ECommerceAPI.Data;
using ECommerceAPI.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repository
{
	public class ProductsRepository : IProductsRepository
	{
		private readonly ECommerceDbContext dbContext;
		private readonly IMapper mapper;

		public ProductsRepository(ECommerceDbContext dbContext, IMapper mapper) 
		{
			this.dbContext = dbContext;
			this.mapper = mapper;
		}

		public async Task<List<ProductDTO>> GetAllAsync()
		{
			var products = await dbContext.Products.ToListAsync();
			return mapper.Map<List<ProductDTO>>(products);
		}

		public async Task<ProductDTO> GetByIdAsync(Guid id)
		{
			var domainProduct = await dbContext.Products.FirstOrDefaultAsync(o => o.ID == id);
			return mapper.Map<ProductDTO>(domainProduct);
		}

		public async Task<ProductDTO?> CreateAsync(AddProductDTO productDTO)
		{
			var domainProduct = mapper.Map<Product>(productDTO);
			var createProduct = await dbContext.Products.AddAsync(domainProduct);
			if (createProduct == null)
			{
				return null;
			}
			await dbContext.SaveChangesAsync();
			return mapper.Map<ProductDTO>(domainProduct);
		}

		public async Task<ProductDTO?> UpdateByIdAsync(Guid id, UpdateProductDTO updateProductDTO)
		{
			var existingProduct = await dbContext.Products.FirstOrDefaultAsync(o => o.ID == id);
			if (existingProduct == null)
			{
				return null;
			}
			existingProduct.Name = updateProductDTO.Name;
			existingProduct.Url = updateProductDTO.Url;
			existingProduct.ImageUrl = updateProductDTO.ImageUrl;
			existingProduct.Company = updateProductDTO.Company;
			existingProduct.Quantity = updateProductDTO.Quantity;
			existingProduct.Price = updateProductDTO.Price;
			existingProduct.Sale = updateProductDTO.Sale;

			await dbContext.SaveChangesAsync();

			return mapper.Map<ProductDTO>(existingProduct);
		}

		public async Task<ProductDTO?> DeleteByIdAsync(Guid id)
		{
			var existingProduct = await dbContext.Products.FirstOrDefaultAsync(o => o.ID == id);
			if (existingProduct == null)
			{
				return null;
			}
			dbContext.Remove(existingProduct);
			await dbContext.SaveChangesAsync();
			return mapper.Map<ProductDTO>(existingProduct);
		}

		public async Task<List<ProductDTO>> DeleteAllAsync()
		{
			var products = await dbContext.Products.ToListAsync();
			dbContext.RemoveRange(products);
			await dbContext.SaveChangesAsync();
			return mapper.Map<List<ProductDTO>>(products);
		}
	}
}
