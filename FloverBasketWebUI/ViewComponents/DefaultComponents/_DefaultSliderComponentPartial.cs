using FloverBasketWebUI.Dtos.SliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FloverBasketWebUI.ViewComponents.DefaultComponents
{
  public class _DefaultSliderComponentPartial : ViewComponent
  {
    HttpClientHandler handler = new HttpClientHandler
    {
      // Sertifika doğrulamasını devre dışı bırak
      ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
    };
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync("https://localhost:7230/api/Sliders");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData= await responseMessage.Content.ReadAsStringAsync();
        var value=JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
        return View(value);
      }
      return View();
    }



















  }
}
