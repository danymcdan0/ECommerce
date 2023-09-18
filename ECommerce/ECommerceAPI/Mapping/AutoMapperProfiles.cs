using AutoMapper;
using ECommerceAPI.Models.Domains;

namespace ECommerceAPI.Mapping
{
	public class AutoMapperProfiles: Profile
	{
		public AutoMapperProfiles() 
		{
			CreateMap<Product, ProductDTO>().ReverseMap();
			CreateMap<Product, AddProductDTO>().ReverseMap();
			CreateMap<Product, UpdateProductDTO>().ReverseMap();
		}
	}
}
