using AutoMapper;
using FlavorB.BusinessLayer.Abstract;
using FlavorB.DtoLayer.SocialMedyaDto;
using FlavorB.DtoLayer.TestimonialDto;
using FlavorB.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlavorBasketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestimonialController : ControllerBase
  {
    private readonly ITestimonialService _testimonialService;
    private readonly IMapper _mapper;
    public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
    {
      _testimonialService = testimonialService;
      _mapper = mapper;
    }
    [HttpGet]
    public IActionResult TestimonialList()
    {
      var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetAll());
      return Ok(value);
    }
    [HttpPost]
    public IActionResult CreateSocialMedya(CreateTestimonialDto testimonialDto)
    {
      _testimonialService.TAdd(new Testimonial()
      {
        Comment=testimonialDto.Comment,
        ImageUrl=testimonialDto.ImageUrl,
        Name=testimonialDto.Name,
        Status=testimonialDto.Status,
        Title=testimonialDto.Title

      });
      return Ok("Müşteri Yorum Bilgisi Eklendi");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteTestimonial(int id) 
    {
      var value = _testimonialService.TGetByID(id);
      _testimonialService.TDelete(value);
      return Ok("Müşteri Yorum Bilgisi Silindi");
    }
    [HttpGet("{id}")]
    public IActionResult GetTestimonial(int id)
    {
      var value = _testimonialService.TGetByID(id);
      return Ok(value);
    }
    [HttpPut]
    public IActionResult UpdateTestimonial(UpdateTestimonialDto testimonialDto)
    {
      _testimonialService.TUpdate(new Testimonial()
      {
        Comment = testimonialDto.Comment,
        ImageUrl=testimonialDto.ImageUrl,
        Name=testimonialDto.Name,
        Status=testimonialDto.Status,
        Title=testimonialDto.Title,
        TestimonialID=testimonialDto.TestimonialID
      });
      return Ok("Müşteri Yorum Bilgileri Güncellendi");
    }































  }
}
