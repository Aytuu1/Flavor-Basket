using AutoMapper;
using FlavorB.DtoLayer.SocialMedyaDto;
using FlavorB.EntityLayer.Entities;

namespace FlavorBasketAPI.Mapping
{
  public class SocialMediaMapping : Profile
  {
    public SocialMediaMapping()
    {
      CreateMap<SocialMedya, ResultSocialMedyaDto>().ReverseMap();
      CreateMap<SocialMedya, GetSocialMedyaDto>().ReverseMap();
      CreateMap<SocialMedya, CreateSocialMedyaDto>().ReverseMap();
      CreateMap<SocialMedya, UpdateSocialMedyaDto>().ReverseMap();
    }
  }
}
