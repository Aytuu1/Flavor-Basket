using FloverBasketWebUI.Dtos.NotificationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FloverBasketWebUI.Controllers
{
  public class NotificationController : Controller
  {

    HttpClientHandler handler = new HttpClientHandler
    {
      // Sertifika doğrulamasını devre dışı bırak
      ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
    };
    private readonly IHttpClientFactory _httpClientFactory;

    public NotificationController(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync("https://localhost:7230/api/Notifications");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var value = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
        return View(value);
      }
      return View();
    }
    [HttpGet]
    public IActionResult CreateNotification()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotification)
    {
      var client = new HttpClient(handler);
      var jsonData = JsonConvert.SerializeObject(createNotification);
      StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var responseMessage = await client.PostAsync("https://localhost:7230/api/Notifications", stringContent);
      if (responseMessage.IsSuccessStatusCode)
      {

        return RedirectToAction("Index");
      }
      return View();
    }
    public async Task<IActionResult> DeleteNotification(int id)
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.DeleteAsync($"https://localhost:7230/api/Notifications/{id}");
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateNotification(int id)
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync($"https://localhost:7230/api/Notifications/{id}");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
        return View(values);
      }
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationdto)
    {
      var client = new HttpClient(handler);
      var jsonData = JsonConvert.SerializeObject(updateNotificationdto);
      StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var responseMessage = await client.PutAsync("https://localhost:7230/api/Notifications", stringContent);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return View();
    }
    public async Task<IActionResult> NotificationStatusTrue(int id)
    {
      var client = new HttpClient(handler);
      await client.GetAsync($"https://localhost:7230/api/Notifications/NotificationChangeToTrue/{id}");    
      return RedirectToAction("Index");
    }
    public async Task<IActionResult> NotificationStatusFalse(int id)
    {
      var client = new HttpClient(handler);
      await client.GetAsync($"https://localhost:7230/api/Notifications/NotificationChangeToFalse/{id}");
      return RedirectToAction("Index");
    }






  }
}
