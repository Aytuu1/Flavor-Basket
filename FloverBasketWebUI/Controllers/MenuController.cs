﻿using FloverBasketWebUI.Dtos.BasketDtos;
using FloverBasketWebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FloverBasketWebUI.Controllers
{
  [AllowAnonymous]
  public class MenuController : Controller
  {
    HttpClientHandler handler = new HttpClientHandler
    {
      // Sertifika doğrulamasını devre dışı bırak
      ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
    };
    private readonly IHttpClientFactory _httpClientFactory;
    public MenuController(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
      var client = new HttpClient(handler);
      var responseMessage = await client.GetAsync("https://localhost:7230/api/Product");
      var jsonData = await responseMessage.Content.ReadAsStringAsync();
      var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
      return View(values);
    }
    [HttpPost]
    public async Task<IActionResult> AddBasket(int id)
    {
      CreateBasketDto createBasketDto = new CreateBasketDto();
      createBasketDto.ProductID= id;
      var client = new HttpClient(handler);
      var jsonData = JsonConvert.SerializeObject(createBasketDto);
      StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var responseMessage = await client.PostAsync("https://localhost:7230/api/Basket", content);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return Json(createBasketDto);
    }













  }
}
