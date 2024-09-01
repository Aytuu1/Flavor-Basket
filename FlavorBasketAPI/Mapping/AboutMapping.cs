using AutoMapper;
using FlavorB.DtoLayer.AboutDto;
using FlavorB.EntityLayer.Entities;

namespace FlavorBasketAPI.Mapping
{
  public class AboutMapping : Profile
  {
    public AboutMapping()
    {
      CreateMap<About, ResultAboutDto>().ReverseMap();
      CreateMap<About, CreateAboutDto>().ReverseMap();
      CreateMap<About, UpdateAboutDto>().ReverseMap();
      CreateMap<About, GetAboutDto>().ReverseMap();
    }
  }
}
