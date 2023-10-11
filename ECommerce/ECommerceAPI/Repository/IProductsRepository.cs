using ECommerceAPI.Models.Domains;

namespace ECommerceAPI.Repository
{
	public interface IProductsRepository
	{
		public Task<List<ProductDTO>> GetAllAsync();

		public Task<ProductDTO> GetByIdAsync(Guid id);

		public Task<ProductDTO> CreateAsync(AddProductDTO addProductDTO);

		public Task<ProductDTO> UpdateByIdAsync(Guid id, UpdateProductDTO updateProductDTO);

		public Task<ProductDTO> DeleteByIdAsync(Guid id);

		public Task<List<ProductDTO>> DeleteAllAsync();
	}
}
