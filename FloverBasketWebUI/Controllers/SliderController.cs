
using FloverBasketWebUI.Dtos.SliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
namespace FloverBasketWebUI.Controllers
{
	public class SliderController : Controller
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			// Sertifika doğrulamasını devre dışı bırak
			ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
		};
		private readonly IHttpClientFactory _httpClientFactory;
		public SliderController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient(handler);
			var responseMessage = await client.GetAsync("https://localhost:7230/api/Sliders");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateSlider()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateSlider(CreateSliderDto createSlider)
		{
			var client = new HttpClient(handler);
			var jsonData = JsonConvert.SerializeObject(createSlider);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7230/api/Sliders", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteSlider(int id)
		{
			var client = new HttpClient(handler);
			var responseMessage = await client.DeleteAsync($"https://localhost:7230/api/Sliders/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateSlider(int id)
		{
			var client = new HttpClient(handler);
			var responseMessage = await client.GetAsync($"https://localhost:7230/api/Sliders/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSlider)
		{
			var client = new HttpClient(handler);
			var jsonData = JsonConvert.SerializeObject(updateSlider);
			StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:7230/api/Sliders", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


















	}
}
