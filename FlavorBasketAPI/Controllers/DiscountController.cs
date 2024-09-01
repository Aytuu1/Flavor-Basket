using AutoMapper;
using FlavorB.BusinessLayer.Abstract;
using FlavorB.DtoLayer.ContactDto;
using FlavorB.DtoLayer.DiscountDto;
using FlavorB.EntityLayer.Entities;
using FlavorBasketAPI.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlavorBasketAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _discountedService;
		private readonly IMapper _mapper;
		public DiscountController(IDiscountService discountedService, IMapper mapper)
		{
			_discountedService = discountedService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult DiscountList()
		{
			var value = _mapper.Map<List<ResultDiscountDto>>(_discountedService.TGetAll());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateDiscount(CreateDiscountDto discountDto)
		{
			_discountedService.TAdd(new Discount()
			{
				Amount = discountDto.Amount,
				Description = discountDto.Description,
				ImageUrl = discountDto.ImageUrl,
				Title = discountDto.Title,
				Status =false

			});
			return Ok("İndirim Bilgisi Eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteDiscount(int id)
		{
			var value = _discountedService.TGetByID(id);
			_discountedService.TDelete(value);
			return Ok("İndirim Bilgisi Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetDiscount(int id)
		{
			var value = _discountedService.TGetByID(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateContact(UpdateDiscountDto discountDto)
		{
			_discountedService.TUpdate(new Discount()
			{
				DiscountID = discountDto.DiscountID,
				Amount = discountDto.Amount,
				Description = discountDto.Description,
				ImageUrl = discountDto.ImageUrl,
				Title = discountDto.Title,
				Status = false

			});
			return Ok("İndirim Bilgileri Güncellendi");
		}
		[HttpPost("TChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_discountedService.TChangeStatusToTrue(id);
			return Ok("Ürün İndirimi Aktif Hale Getirildi ");
		}
		[HttpPost("TChangeStatusToFalse/{id}")]
		public IActionResult TChangeStatusToFalse(int id)
		{
			_discountedService.TChangeStatusToFalse(id);
			return Ok("Ürün İndirimi Pasif Hale Getirildi ");
		}
		[HttpGet("GetListByStatusTrue")]
		public IActionResult GetListByStatusTrue()
		{
			return Ok(_discountedService.TGetListByStatusTrue());
		}







	}
}
