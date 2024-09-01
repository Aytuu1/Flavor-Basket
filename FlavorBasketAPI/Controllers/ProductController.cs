using AutoMapper;
using FlavorB.BusinessLayer.Abstract;
using FlavorB.DataAccessLayer.Concrete;
using FlavorB.DtoLayer.FeatureDto;
using FlavorB.DtoLayer.ProductDto;
using FlavorBasketAPI.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlavorBasketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public ProductController(IProductService productService, IMapper mapper)
    {
      _productService = productService;
      _mapper = mapper;
    }
    [HttpGet]
    public IActionResult productList()
    {
      var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
      return Ok(value);
    }
    [HttpGet("ProductListWithCategory")]
    public IActionResult ProductListWithCategory()
    {
      var context = new FlavorBContext();
      var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
      {
        Description = y.Description,
        ImageUrl = y.ImageUrl,
        Price = y.Price,
        ProductID = y.ProductID,
        ProductStatus = y.ProductStatus,
        ProductName = y.ProductName,
        CategoryName = y.Category.CategoryName
      }).ToList();
      return Ok(values.ToList());
    }
    [HttpPost]
    public IActionResult CreateProduct(CreateProductDto productDto)
    {
      _productService.TAdd(new Product()
      {
        Description = productDto.Description,
        ImageUrl = productDto.ImageUrl,
        Price = productDto.Price,
        ProductName = productDto.ProductName,
        ProductStatus=productDto.ProductStatus,
        CategoryID=productDto.CategoryID
      });
      return Ok("Ürün Bilgisi Eklendi");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
      var value = _productService.TGetByID(id);
      _productService.TDelete(value);
      return Ok("Ürün Bilgisi Silindi");
    }
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
      var value = _productService.TGetByID(id);
      return Ok(value);
    }
    [HttpPut]
    public IActionResult UpdateProduct(UpdateProductDto productDto)
    {
      _productService.TUpdate(new Product()
      {
        ProductName = productDto.ProductName,
        Description = productDto.Description,
        ProductStatus = productDto.ProductStatus,
        ImageUrl= productDto.ImageUrl,
        Price= productDto.Price,
        ProductID = productDto.ProductID,
        CategoryID = productDto.CategoryID
        
      });
      return Ok("Ürün Bilgileri Güncellendi");
    }
    [HttpGet("ProductCount")]
    public IActionResult ProductCount()
    {
      return Ok(_productService.TProductCount());
    }

    [HttpGet("ProductCountByHamburger")]
    public IActionResult ProductCountByHamburger()
    {
      return Ok(_productService.TProductCountByCategoryNameHamburger());
    }
    [HttpGet("ProductCountByDrink")]
    public IActionResult ProductCountByDrink()
    {
      return Ok(_productService.TProductCountByCategoryNameDrink());
    }
    [HttpGet("ProductPriceAvg")]
    public IActionResult ProductPriceAvg()
    {
      return Ok(_productService.TProductPriceAvg());
    }
    [HttpGet("ProductNamePriceMax")]
    public IActionResult ProductNamePriceMax()
    {
      return Ok(_productService.TProductNameByMaxPrice());
    }
    [HttpGet("ProductNamePriceMin")]
    public IActionResult ProductNamePriceMin()
    {
      return Ok(_productService.TProductNameByMinPrice());
    }
    [HttpGet("ProductHamburgerPriceAverage")]
    public IActionResult ProductHamburgerPriceAverage()
    {
      return Ok(_productService.TProductPriceByHamburger());
    }








  }
}
