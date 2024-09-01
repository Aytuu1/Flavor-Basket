using AutoMapper;
using FlavorB.DtoLayer.ProductDto;
using FlavorBasketAPI.DAL.Entities;

namespace FlavorBasketAPI.Mapping
{
  public class ProductMapping:Profile
  {
        public ProductMapping()
        {
            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,GetProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,ResultProductWithCategory>().ReverseMap();
        }
    }
}
