using FlavorB.BusinessLayer.Abstract;
using FlavorB.DtoLayer.AboutDto;
using FlavorB.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlavorBasketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AboutController : ControllerBase
  {
    private readonly IAboutService _aboutService;
    public AboutController(IAboutService aboutService)
    {
      _aboutService = aboutService;
    }

    [HttpGet]
    public IActionResult AboutList()
    {
      var values=_aboutService.TGetAll();
      return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateAbout(CreateAboutDto createAbout)
    {
      About about = new About
      {
        Title= createAbout.Title,
        Description= createAbout.Description,
        ImageUrl= createAbout.ImageUrl,
      };
      _aboutService.TAdd(about);
      return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAbout(int id)
    {
      var values=_aboutService.TGetByID(id);
      _aboutService.TDelete(values);
      return Ok("Hakkımda Alanı Silindi");
    }
    [HttpPut]
    public IActionResult UpdateAbout(UpdateAboutDto updateAbout)
    {
      _aboutService.TUpdate(new About()
      {
        AboutID= updateAbout.AboutID,
        Title = updateAbout.Title,
        Description = updateAbout.Description,
        ImageUrl = updateAbout.ImageUrl
        
      });
      return Ok("Hakkımızda Kısmı Başarıyla Güncellendi");
    }

    [HttpGet("{id}")]
    public IActionResult GetAbout(int id) 
    {
      var values = _aboutService.TGetByID(id);
      return Ok(values);
    }










  }
}
