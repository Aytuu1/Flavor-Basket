using AutoMapper;
using FlavorB.DtoLayer.DiscountDto;
using FlavorBasketAPI.DAL.Entities;

namespace FlavorBasketAPI.Mapping
{
  public class DiscountMapping : Profile
  {
    public DiscountMapping()
    {
      CreateMap<Discount, ResultDiscountDto>().ReverseMap();
      CreateMap<Discount, GetDiscountDto>().ReverseMap();
      CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
      CreateMap<Discount, CreateDiscountDto>().ReverseMap();
    }
  }
}
