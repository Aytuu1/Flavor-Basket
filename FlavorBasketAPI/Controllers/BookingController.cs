using FlavorB.BusinessLayer.Abstract;
using FlavorB.DtoLayer.BookingDto;
using FlavorB.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlavorBasketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BookingController : ControllerBase
  {
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
      _bookingService = bookingService;
    }

    [HttpGet]
    public IActionResult BookingList()
    {
      var values = _bookingService.TGetAll();
      return Ok(values);

    }
    [HttpPost]
    public IActionResult CreateBooking(CreateBookingDto createBooking)
    {
      Booking booking = new Booking
      {
        Name = createBooking.Name,
        Mail = createBooking.Mail,
        Phone = createBooking.Phone,
        Date = createBooking.Date,
        Description=createBooking.Description,
        PersonCount = createBooking.PersonCount
      };
      _bookingService.TAdd(booking);
      return Ok("Rezervasyon Yapıldı");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBooking(int id)
    {
      var values = _bookingService.TGetByID(id);
      _bookingService.TDelete(values);
      return Ok("Rezervasyon silindi");
    }
    [HttpPut]
    public IActionResult BookigUpdate(UpdateBookingDto updateBooking)
    {
      Booking booking = new Booking
      {
        Date = updateBooking.Date,
        Mail = updateBooking.Mail,
        Phone = updateBooking.Phone,
        Name = updateBooking.Name,
        PersonCount = updateBooking.PersonCount
      };
      _bookingService.TUpdate(booking);
      return Ok("Rezervasyon başarıyla güncellendi");
    }
    [HttpGet("{id}")]
    public IActionResult GetBooking(int id)
    {
      var values = _bookingService.TGetByID(id);
      return Ok(values);
    }
    [HttpGet("BookoingStatusApproved/{id}")]
    public IActionResult BookoingStatusApproved(int id)
    {
      _bookingService.TBookoingStatusApproved(id);
      return Ok("Rezervasyon Onaylandı");
    }
    [HttpGet("BookoingStatusCancelled/{id}")]
    public IActionResult BookoingStatusCancelled(int id)
    {
      _bookingService.TBookoingStatusCancelled(id);
      return Ok("Rezervasyon İptal Edildi");
    }








  }
}
