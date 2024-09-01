using FloverBasketWebUI.Dtos.SocialMedyaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FloverBasketWebUI.Controllers
{
  public class SocialMedyaController : Controller
  {
    HttpClientHandler handler = new HttpClientHandler
    {
      // Sertifika doğrulamasını devre dışı bırak
      ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
    };
    private readonly IHttpClientFactory _httpClientFactory;

    public SocialMedyaController(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync("https://localhost:7230/api/SocialMedya");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultSocialMedyaDto>>(jsonData);
        return View(values);
      }
      return View();
    }

    [HttpGet]
    public IActionResult CreateSocialMedya()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateSocialMedya(CreateSocialMedyaDto createSocialMedya)
    {
      var client = new HttpClient(handler);
      var jsonData = JsonConvert.SerializeObject(createSocialMedya);
      StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var responseMessage = await client.PostAsync("https://localhost:7230/api/SocialMedya", stringContent);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return View();
    }
    public async Task<IActionResult> DeleteSocialMedya(int id)
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.DeleteAsync($"https://localhost:7230/api/SocialMedya/{id}");
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateSocialMedya(int id)
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync($"https://localhost:7230/api/SocialMedya/{id}");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<UpdateSocialMedyaDto>(jsonData);
        return View(values);
      }
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateSocialMedya(UpdateSocialMedyaDto updateSocialMedya)
    {
      var client = new HttpClient(handler);
      var jsonData = JsonConvert.SerializeObject(updateSocialMedya);
      StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var responseMessage = await client.PutAsync("https://localhost:7230/api/SocialMedya/", stringContent);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return View();
    }

   


















  }
}
