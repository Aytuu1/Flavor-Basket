using FloverBasketWebUI.Dtos.DiscountDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FloverBasketWebUI.ViewComponents.DefaultComponents
{
  public class _DefaultOfferComponentPartial : ViewComponent
  {
    HttpClientHandler handler = new HttpClientHandler
    {
      // Sertifika doğrulamasını devre dışı bırak
      ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
    };
    private readonly IHttpClientFactory _httpClientFactory;
    public _DefaultOfferComponentPartial(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync("https://localhost:7230/api/Discount/GetListByStatusTrue");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var value = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
        return View(value);
      }

      return View();
    }




















  }
}
