using AutoMapper;
using FlavorB.DtoLayer.SliderDto;
using FlavorB.EntityLayer.Entities;
using FlavorBasketAPI.DAL.Entities;

namespace FlavorBasketAPI.Mapping
{
	public class SliderMapping : Profile
	{
		public SliderMapping()
		{
			CreateMap<Slider, ResultSliderDto>().ReverseMap();
		}
	}
}
