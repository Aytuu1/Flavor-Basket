using AutoMapper;
using FlavorB.BusinessLayer.Abstract;
using FlavorB.DtoLayer.DiscountDto;
using FlavorB.DtoLayer.SliderDto;
using FlavorB.EntityLayer.Entities;
using FlavorBasketAPI.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlavorBasketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SlidersController : ControllerBase
  {
    private readonly ISliderService _sliderService;
    private readonly IMapper _mapper;
    public SlidersController(ISliderService sliderService, IMapper mapper)
    {
			_sliderService = sliderService;
      _mapper = mapper;
    }
    [HttpGet]
    public IActionResult SliderList()
    {
      var value = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetAll());
      return Ok(value);
    }
    [HttpPost]
    public IActionResult CreateSlider(CreateSliderDto sliderDto)
    {
			_sliderService.TAdd(new Slider()
      {
        Description1 = sliderDto.Description1,
        Description2 = sliderDto.Description2,
        Description3 = sliderDto.Description3,
        Title1 = sliderDto.Title1,
        Title2 = sliderDto.Title2,
        Title3 = sliderDto.Title3
      });
      return Ok("Öne Çıkan Bilgisi Eklendi");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteSlider(int id)
    {
      var value = _sliderService.TGetByID(id);
			_sliderService.TDelete(value);
      return Ok("Öne Çıkan Bilgisi Silindi");
    }
    [HttpGet("{id}")]
    public IActionResult GetSlider(int id)
    {
      var value = _sliderService.TGetByID(id);
      return Ok(value);
    }
    [HttpPut]
    public IActionResult UpdateSlider(UpdateSliderDto sliderDto)
    {
			_sliderService.TUpdate(new Slider()
      {
        
        Title1 = sliderDto.Title1,
        Description1 = sliderDto.Description1,
        Description2 = sliderDto.Description2,
        Title2 = sliderDto.Title2,
        Description3= sliderDto.Description3,
        Title3 = sliderDto.Title3,
        SliderID=sliderDto.SliderID
      });
      return Ok("Öne Çıkan Bilgileri Güncellendi");
    }
















  }
}
