using FloverBasketWebUI.Dtos.CategoryDtos;
using FloverBasketWebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace FloverBasketWebUI.Controllers
{
	public class ProductController : Controller
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			// Sertifika doğrulamasını devre dışı bırak
			ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
		};
		private readonly IHttpClientFactory _httpClientFactory;
		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient(handler);
			var responseMessage = await client.GetAsync("https://localhost:7230/api/Product/ProductListWithCategory");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			var client = new HttpClient(handler);
			var responseMessage = await client.GetAsync("https://localhost:7230/api/Category");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
			List<SelectListItem> CategoryItem = values.Select(x => new SelectListItem
			{
				Text = x.CategoryName,
				Value = x.CategoryID.ToString()
			}).ToList();

			ViewBag.CategoryItem = CategoryItem;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			createProductDto.ProductStatus = true;
			var client = new HttpClient(handler);
			var jsonData = JsonConvert.SerializeObject(createProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7230/api/Product", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var client = new HttpClient(handler);
			var responseMessage = await client.DeleteAsync($"https://localhost:7230/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateProduct(int id)
		{
			var client1 = new HttpClient(handler);
			var responseMessage1 = await client1.GetAsync("https://localhost:7230/api/Category");
			var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
			var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
			List<SelectListItem> CategoryItem = values1.Select(x => new SelectListItem
			{
				Text = x.CategoryName,
				Value = x.CategoryID.ToString()
			}).ToList();

			ViewBag.CategoryItem = CategoryItem;

			var client = new HttpClient(handler);
			var responMessage = await client.GetAsync($"https://localhost:7230/api/Product/{id}");
			if (responMessage.IsSuccessStatusCode)
			{
				var jsonData = await responMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			updateProductDto.ProductStatus = true;
			var client = new HttpClient(handler);
			var jsonData = JsonConvert.SerializeObject(updateProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7230/api/Product/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
























	}
}
