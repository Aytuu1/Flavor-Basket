using FlavorB.BusinessLayer.Abstract;
using FlavorB.DtoLayer.MenuTableDto;
using FlavorB.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlavorBasketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MenuTablesController : ControllerBase
  {
    private readonly IMenuTableService _menuTableService;

    public MenuTablesController(IMenuTableService menuTableService)
    {
      _menuTableService = menuTableService;
    }
    [HttpGet("MenuTableCount")]
    public IActionResult MenuTableCount()
    {
      return Ok(_menuTableService.TMenuTableCount());
    }
    [HttpGet]
    public IActionResult MenuTableList()
    {
      var values = _menuTableService.TGetAll();
      return Ok(values);
    }
    [HttpPost]
    public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTable)
    {
      MenuTable menuTable = new()
      {
        Name = createMenuTable.Name,
        Status = false,
      };
      _menuTableService.TAdd(menuTable);
      return Ok("Masa Başarılı bir şekilde eklendi");
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteMenuTable(int id)
    {
      var value=_menuTableService.TGetByID(id);
      _menuTableService.TDelete(value);
      return Ok("Masa başarıyla silindi");
    }
    [HttpPut]
    public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTable)
    {
      MenuTable menuTable = new()
      {
        Name=updateMenuTable.Name,
        Status=false,
        MenuTableID=updateMenuTable.MenuTableID
      };
      _menuTableService.TUpdate(menuTable);
      return Ok("Masa Başarıyla güncellendi");
    }
    [HttpGet("{id}")]
    public IActionResult GetMenuTable(int id) 
    {
      var value = _menuTableService.TGetByID(id);
      return Ok(value);
    }










  }
}
