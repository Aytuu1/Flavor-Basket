
using FloverBasketWebUI.Dtos.MessageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FloverBasketWebUI.Controllers
{
	[AllowAnonymous]
  public class DefaultController : Controller
  {
		HttpClientHandler handler = new HttpClientHandler
		{
			// Sertifika doğrulamasını devre dışı bırak
			ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
		};
		public IActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public PartialViewResult SendMessage()
    {
      return PartialView();
    }
    [HttpPost]
    public async Task<IActionResult> SendMessage(CreateMessageDto createMessage)
    {
			var client = new HttpClient(handler);
			var jsonData = JsonConvert.SerializeObject(createMessage);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7230/api/Messages", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}
















  }
}
