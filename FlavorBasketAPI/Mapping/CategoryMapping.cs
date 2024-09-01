using AutoMapper;
using FlavorB.DtoLayer.CategoryDto;
using FlavorBasketAPI.DAL.Entities;

namespace FlavorBasketAPI.Mapping
{
  public class CategoryMapping : Profile
  {
    public CategoryMapping()
    {
      CreateMap<Category, ResultCategoryDto>().ReverseMap();
      CreateMap<Category, GetCategoryDto>().ReverseMap();
      CreateMap<Category, UpdateCategoryDto>().ReverseMap();
      CreateMap<Category, CreateCategoryDto>().ReverseMap();
    }
  }
}
