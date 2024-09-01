using AutoMapper;
using FlavorB.BusinessLayer.Abstract;
using FlavorB.DtoLayer.CategoryDto;
using FlavorBasketAPI.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlavorBasketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
      _categoryService = categoryService;
      _mapper = mapper;
    }
    [HttpGet]
    public IActionResult CategoryList()
    {
      var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetAll());
      return Ok(value);
    }
    [HttpPost]
    public IActionResult CreateCategory(ResultCategoryDto categoryDto)
    {
      _categoryService.TAdd(new Category()
      {
        CategoryName = categoryDto.CategoryName,
        CategoryStatus = true
      });
      return Ok("Kategori Eklendi");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
      var value = _categoryService.TGetByID(id);
      _categoryService.TDelete(value);
      return Ok("Kategori Silindi");
    }
    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
      var value = _categoryService.TGetByID(id);
      return Ok(value);
    }
    [HttpPut]
    public IActionResult UpdateCategory(UpdateCategoryDto categoryDto)
    {
      _categoryService.TUpdate(new Category()
      {
        CategoryID = categoryDto.CategoryID,
        CategoryName = categoryDto.CategoryName,
        CategoryStatus = categoryDto.CategoryStatus
      });
      return Ok("Kategori Güncellendi");
    }
    [HttpGet("CategoryCount")]
    public IActionResult CategoryCount()
    {
      return Ok(_categoryService.TCategoryCount());
    }
    [HttpGet("ActiveCategoryCount")]
    public IActionResult ActiveCategoryCount()
    {
      return Ok(_categoryService.TActiveCategoryCount());
    }
    [HttpGet("PassiveCategoryCount")]
    public IActionResult PassiveCategoryCount()
    {
      return Ok(_categoryService.TPassiveCategoryCount());
    }










  }
}
