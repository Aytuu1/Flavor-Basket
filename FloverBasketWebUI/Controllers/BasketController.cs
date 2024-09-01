using FloverBasketWebUI.Dtos.BasketDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FloverBasketWebUI.Controllers
{
  [AllowAnonymous]
  public class BasketController : Controller
  {
    HttpClientHandler handler = new HttpClientHandler
    {
      // Sertifika doğrulamasını devre dışı bırak
      ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
    };
    private readonly IHttpClientFactory _httpClientFactory;
    public BasketController(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync("https://localhost:7230/api/Basket/BasketListByMenuTableWithProducts?id=4");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
        return View(values);
      }
      return View();
    }
    public async Task<IActionResult> DeleteBasket(int id)
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.DeleteAsync($"https://localhost:7230/api/Basket/{id}");
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return NoContent();
    }













  }
}
