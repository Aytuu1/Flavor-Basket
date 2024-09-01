using AutoMapper;
using FlavorB.DtoLayer.FeatureDto;
using FlavorBasketAPI.DAL.Entities;

namespace FlavorBasketAPI.Mapping
{
  public class FeatureMapping : Profile
  {
    public FeatureMapping()
    {
      CreateMap<Feature, ResultFeatureDto>().ReverseMap();
      CreateMap<Feature, GetFeatureDto>().ReverseMap();
      CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
      CreateMap<Feature, CreateFeatureDto>().ReverseMap();

    }
  }
}
