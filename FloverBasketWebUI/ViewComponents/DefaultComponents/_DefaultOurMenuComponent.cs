using FloverBasketWebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FloverBasketWebUI.ViewComponents.DefaultComponents
{
  public class _DefaultOurMenuComponent:ViewComponent
  {
    HttpClientHandler handler = new HttpClientHandler
    {
      // Sertifika doğrulamasını devre dışı bırak
      ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
    };
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultOurMenuComponent(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync("https://localhost:7230/api/Product");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData= await responseMessage.Content.ReadAsStringAsync();
        var values=JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
        return View(values);
      }
      return View();
    }


















  }
}
