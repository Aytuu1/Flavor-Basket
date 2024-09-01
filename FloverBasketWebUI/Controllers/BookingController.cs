using FloverBasketWebUI.Dtos.BookingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FloverBasketWebUI.Controllers
{
  public class BookingController : Controller
  {
    HttpClientHandler handler = new HttpClientHandler
    {
      // Sertifika doğrulamasını devre dışı bırak
      ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
    };
    private readonly IHttpClientFactory _httpClientFactory;

    public BookingController(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync("https://localhost:7230/api/Booking");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
        return View(values);
      }
      return View();
    }
    [HttpGet]
    public IActionResult CreateBooking()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingDto createBooking)
    {
      createBooking.Description = "Rezervasyon Alındı";
      var client = new HttpClient(handler);
      var jsonData = JsonConvert.SerializeObject(createBooking);
      StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var responseMessage = await client.PostAsync("https://localhost:7230/api/Booking", stringContent);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return View();
    }
    public async Task<IActionResult> DeleteBooking(int id)
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.DeleteAsync($"https://localhost:7230/api/Booking/{id}");
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateBooking(int id)
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync($"https://localhost:7230/api/Booking/{id}");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var value = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
        return View(value);
      }
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBooking)
    {
      var client = new HttpClient(handler);
      var jsonData = JsonConvert.SerializeObject(updateBooking);
      StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var responseMessage = await client.PutAsync("https://localhost:7230/api/Booking/", stringContent);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return View();
    }
    public async Task<IActionResult> BookoingStatusApproved(int id)
    {
      var client=new HttpClient(handler);
      await client.GetAsync($"https://localhost:7230/api/Booking/BookoingStatusApproved/{id}");
      return RedirectToAction("Index");
    }
    public async Task<IActionResult> BookoingStatusCancelled(int id)
    {
      var client = new HttpClient(handler);
      await client.GetAsync($"https://localhost:7230/api/Booking/BookoingStatusCancelled/{id}");
      return RedirectToAction("Index");
    }







  }
}
