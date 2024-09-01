using FloverBasketWebUI.Dtos.SocialMedyaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FloverBasketWebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutSocialMediaComponentPartial : ViewComponent
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			// Sertifika doğrulamasını devre dışı bırak
			ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
		};

		public async Task<IViewComponentResult> InvokeAsync()
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
	}
}

