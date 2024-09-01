using FloverBasketWebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FloverBasketWebUI.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			// Sertifika doğrulamasını devre dışı bırak
			ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
		};
		private readonly IHttpClientFactory _httpClientFactory;
		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient(handler); // Api istek için client oluşturuyoruz.
			var responseMessage = await client.GetAsync("https://localhost:7230/api/Contact"); // Getirmek istediğimiz alana istek atıyoruz
			if (responseMessage.IsSuccessStatusCode) // eğer istek başarılı dönerse if bloğuna giriyor
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Getireceğimiz verileri okuyup değişkene alıyoruz
				var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData); // okuduğumuz verileri json formatından çevirip listeliyoruz
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto createContact)
		{
			var client = new HttpClient(handler);
			var jsonData = JsonConvert.SerializeObject(createContact);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7230/api/Contact", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteContact(int id)
		{
			var client = new HttpClient(handler);
			var responseMessage = await client.DeleteAsync($"https://localhost:7230/api/Contact/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateContact(int id)
		{
			var client = new HttpClient(handler);
			var responseMessage = await client.GetAsync($"https://localhost:7230/api/Contact/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
		{
			var client = new HttpClient(handler);
			var jsonData = JsonConvert.SerializeObject(updateContactDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7230/api/Contact",stringContent);
			if (responseMessage.IsSuccessStatusCode) 
			{
				return RedirectToAction("Index");

			}
			return View();
		}
		[HttpGet]
		public IActionResult ContactCıtır()
		{
			return View();
		}



















	}
}
