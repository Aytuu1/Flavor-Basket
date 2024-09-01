using AutoMapper;
using FlavorB.DtoLayer.TestimonialDto;
using FlavorB.EntityLayer.Entities;

namespace FlavorBasketAPI.Mapping
{
  public class TestimonialMapping : Profile
  {
    public TestimonialMapping()
    {
      CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
      CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
      CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
      CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
    }
  }
}
