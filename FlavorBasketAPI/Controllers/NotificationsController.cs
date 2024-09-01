using FlavorB.BusinessLayer.Abstract;
using FlavorB.BusinessLayer.Concrete;
using FlavorB.DtoLayer.NotificationDto;
using FlavorB.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlavorBasketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NotificationsController : ControllerBase
  {
    private readonly INotificationService _notificationService;
    public NotificationsController(INotificationService notificationService)
    {
      _notificationService = notificationService;
    }
    [HttpGet]
    public IActionResult NotificationList()
    {

      return Ok(_notificationService.TGetAll());
    }
    [HttpGet("NotificationCountByStatusFalse")]
    public IActionResult NotificationCountByStatusFalse()
    {

      return Ok(_notificationService.TNotificationCountByStatusFalse());
    }
    [HttpGet("GetAllNotificationByFalse")]
    public IActionResult GetAllNotificationByFalse()
    {
      return Ok(_notificationService.TGetAllNotificationByFalse());
    }
    [HttpPost]
    public IActionResult CreateNotification(CreateNotificationDto createNotification)
    {
      Notification notification = new()
      {
        Description = createNotification.Description,
        Icon = createNotification.Icon,
        Status = false,
        Type = createNotification.Type,
        Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
      };
      _notificationService.TAdd(notification);
      return Ok("Ekleme işlemi başarıyla gerçekleştirildi.");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteNotification(int id)
    {
      var value = _notificationService.TGetByID(id);
      _notificationService.TDelete(value);
      return Ok("Silme işlemi başarıyla gerçekleştirildi");
    }
    [HttpGet("{id}")]
    public IActionResult GetNotification(int id)
    {
      var value = _notificationService.TGetByID(id);
      return Ok(value);
    }
    [HttpPut]
    public IActionResult UpdateNotification(UpdateNotificationDto updateNotification)
    {
      Notification notification = new()
      {
        NotificationID = updateNotification.NotificationID,
        Description = updateNotification.Description,
        Icon = updateNotification.Icon,
        Status = updateNotification.Status,
        Type = updateNotification.Type,
        Date = updateNotification.Date
      };
      _notificationService.TUpdate(notification);
      return Ok("Güncelleme işlemi başarıyla yapıldı");
    }
    [HttpGet("NotificationChangeToFalse/{id}")]
    public IActionResult NotificationChangeToFalse(int id)
    {
      _notificationService.TNotificationChangeToFalse(id);
      return Ok("Güncelleme Yapıldı");
    }
    [HttpGet("NotificationChangeToTrue/{id}")]
    public IActionResult NotificationChangeToTrue(int id)
    {
      _notificationService.TNotificationChangeToTrue(id);
      return Ok("Güncelleme Yapıldı");
    }









  }
}
