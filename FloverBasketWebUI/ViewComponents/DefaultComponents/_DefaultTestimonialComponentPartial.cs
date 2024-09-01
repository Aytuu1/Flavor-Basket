using FloverBasketWebUI.Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FloverBasketWebUI.ViewComponents.DefaultComponents
{
  public class _DefaultTestimonialComponentPartial : ViewComponent
  {
    HttpClientHandler handler = new HttpClientHandler
    {
      // Sertifika doğrulamasını devre dışı bırak
      ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
    };
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultTestimonialComponentPartial(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync("https://localhost:7230/api/Testimonial");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonConvert = await responseMessage.Content.ReadAsStringAsync();
        var value = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonConvert);
        return View(value);
      }

      return View();
    }
  }
}
