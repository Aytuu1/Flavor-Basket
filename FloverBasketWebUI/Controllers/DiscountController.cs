using FloverBasketWebUI.Dtos.DiscountDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
namespace FloverBasketWebUI.Controllers
{
	public class DiscountController : Controller
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			// Sertifika doğrulamasını devre dışı bırak
			ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
		};
		private readonly IHttpClientFactory _httpClientFactory;
		public DiscountController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient(handler);
			var responseMessage = await client.GetAsync("https://localhost:7230/api/Discount");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateDiscount()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscount)
		{
			var client = new HttpClient(handler);
			var jsonData = JsonConvert.SerializeObject(createDiscount);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7230/api/Discount", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteDiscount(int id)
		{
			var client = new HttpClient(handler);
			var responseMessage = await client.DeleteAsync($"https://localhost:7230/api/Discount/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateDiscount(int id)
		{
			var client = new HttpClient(handler);
			var responseMessage = await client.GetAsync($"https://localhost:7230/api/Discount/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{

				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscount)
		{
			var client = new HttpClient(handler);
			var jsonData = JsonConvert.SerializeObject(updateDiscount);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7230/api/Discount", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> ChangeStatusToTrue(int id)
		{
			var client = new HttpClient(handler);
			await client.GetAsync($"https://localhost:7230/api/Discount/ChangeStatusToTrue/{id}");
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> ChangeStatusToFalse(int id)
		{
			var client = new HttpClient(handler);
			await client.GetAsync($"https://localhost:7230/api/Discount/ChangeStatusToFalse/{id}");
			return RedirectToAction("Index");
		}


	







	}
}
