using FlavorB.BusinessLayer.Abstract;
using FlavorB.DataAccessLayer.Concrete;
using FlavorB.DtoLayer.BasketDto;
using FlavorB.EntityLayer.Entities;
using FlavorBasketAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlavorBasketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BasketController : ControllerBase
  {
    private readonly IBasketService _basketService;
    public BasketController(IBasketService basketService)
    {
      _basketService = basketService;
    }
    [HttpGet]
    public IActionResult GetBasketByMenuTableID(int id)
    {
      var values = _basketService.TGetBasketByMenuTableNumber(id);
      return Ok(values);
    }
    [HttpGet("BasketListByMenuTableWithProducts")]
    public IActionResult BasketListByMenuTableWithProducts(int id)
    {
      using var context = new FlavorBContext();
      var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id)
        .Select(z => new ResultBasketListWithProducts
        {
          BasketID = z.BasketID,
          Count = z.Count,
          MenuTableID = z.MenuTableID,
          Price = z.Price,
          ProductID = z.ProductID,
          TotalPrice = z.TotalPrice,
          ProductName = z.Product.ProductName
        }
      ).ToList();
      return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateBasket(CreateBasketDto createBasketDto)
    {
      using var context = new FlavorBContext();
      _basketService.TAdd(new Basket()
      {
        Count = 1,
        MenuTableID = 4,
        Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
        TotalPrice=0,
        ProductID=createBasketDto.ProductID, 
      });
      return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBasket(int id) 
    {
      var value = _basketService.TGetByID(id);
      _basketService.TDelete(value);
        return Ok("Ürün Silindi");
    }












  }
}
