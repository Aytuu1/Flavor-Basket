using AutoMapper;
using FlavorB.BusinessLayer.Abstract;
using FlavorB.DtoLayer.CategoryDto;
using FlavorB.DtoLayer.ContactDto;
using FlavorB.EntityLayer.Entities;
using FlavorBasketAPI.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlavorBasketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactController : ControllerBase
  {

    private readonly IContactService _contactService;
    private readonly IMapper _mapper;
    public ContactController(IContactService contactService, IMapper mapper)
    {
      _contactService = contactService;
      _mapper = mapper;
    }
    [HttpGet]
    public IActionResult ContactList()
    {
      var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
      return Ok(value);
    }
    [HttpPost]
    public IActionResult CreateContact(CreateContactDto contactDto)
    {
      _contactService.TAdd(new Contact()
      {
        FooterDescription=contactDto.FooterDescription,
        Location=contactDto.Location,
        Mail=contactDto.Mail,
        Phone=contactDto.Phone,
        FooterTitle = contactDto.FooterTitle,
        OpenDays = contactDto.OpenDays,
        OpenDaysDescription = contactDto.OpenDaysDescription,
        OpenHours = contactDto.OpenHours
      });
      return Ok("İletişim Bilgisi Eklendi");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteContact(int id)
    {
      var value = _contactService.TGetByID(id);
      _contactService.TDelete(value);
      return Ok("İletişim Bilgisi Silindi");
    }
    [HttpGet("{id}")]
    public IActionResult GetContact(int id)
    {
      var value = _contactService.TGetByID(id);
      return Ok(value);
    }
    [HttpPut]
    public IActionResult UpdateContact(UpdateContactDto contactDto)
    {
      _contactService.TUpdate(new Contact()
      {
        ContactID=contactDto.ContactID,
        FooterDescription = contactDto.FooterDescription,
        Location=contactDto.Location,
        Mail=contactDto.Mail,
        Phone=contactDto.Phone,
        FooterTitle=contactDto.FooterTitle,
        OpenDays=contactDto.OpenDays,
        OpenDaysDescription=contactDto.OpenDaysDescription,
        OpenHours = contactDto.OpenHours
        
      });
      return Ok("İletişim Bilgileri Güncellendi");
    }











  }
}
