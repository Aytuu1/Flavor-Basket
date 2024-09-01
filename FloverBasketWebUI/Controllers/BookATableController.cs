using FloverBasketWebUI.Dtos.BookingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FloverBasketWebUI.Controllers
{
  [AllowAnonymous]
  public class BookATableController : Controller
  {
    HttpClientHandler handler = new HttpClientHandler
    {
      // Sertifika doğrulamasını devre dışı bırak
      ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
    };
    private readonly IHttpClientFactory _httpClientFactory;

    public BookATableController(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateBookingDto createBooking)
    {
      var client = new HttpClient(handler);
      var jsonData = JsonConvert.SerializeObject(createBooking);
      StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
      var responseMessage = await client.PostAsync("https://localhost:7230/api/Booking",stringContent);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index","Default");
      }
      return View();
    }





















  }
}
