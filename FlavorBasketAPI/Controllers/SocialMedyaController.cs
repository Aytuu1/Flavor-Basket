using AutoMapper;
using FlavorB.BusinessLayer.Abstract;
using FlavorB.DtoLayer.ProductDto;
using FlavorB.DtoLayer.SocialMedyaDto;
using FlavorB.EntityLayer.Entities;
using FlavorBasketAPI.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlavorBasketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SocialMedyaController : ControllerBase
  {
    private readonly ISocialMedyaService _socialMedyaService;
    private readonly IMapper _mapper;

    public SocialMedyaController(ISocialMedyaService socialMedyaService, IMapper mapper)
    {
      _socialMedyaService = socialMedyaService;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult socialMedyaList()
    {
      var value = _mapper.Map<List<ResultSocialMedyaDto>>(_socialMedyaService.TGetAll());
      return Ok(value);
    }
    [HttpPost]
    public IActionResult CreateSocialMedya(CreateSocialMedyaDto socialMedyaDto)
    {
      _socialMedyaService.TAdd(new SocialMedya()
      {
        Icon=socialMedyaDto.Icon,
        Title =socialMedyaDto.Title,
        Url =socialMedyaDto.Url
      });
      return Ok("Sosyal Medya Bilgisi Eklendi");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteSocialMedya(int id)
    {
      var value = _socialMedyaService.TGetByID(id);
      _socialMedyaService.TDelete(value);
      return Ok("Sosyal Medya Bilgisi Silindi");
    }
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
      var value = _socialMedyaService.TGetByID(id);
      return Ok(value);
    }
    [HttpPut]
    public IActionResult UpdateSocialMedya(UpdateSocialMedyaDto socialMedyaDto)
    {
      _socialMedyaService.TUpdate(new SocialMedya()
      {
       Icon = socialMedyaDto.Icon,
       SocialMediaID=socialMedyaDto.SocialMediaID,
       Title = socialMedyaDto.Title,
       Url = socialMedyaDto.Url
       
      });
      return Ok("Sosyal Medya Bilgileri Güncellendi");
    }

    
























  }
}
