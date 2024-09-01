using FlavorB.BusinessLayer.Abstract;
using FlavorB.DtoLayer.MessageDto;
using FlavorB.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlavorBasketAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly IMessageService _messageService;

		public MessagesController(IMessageService messageService)
		{
			_messageService = messageService;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.TGetAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessage)
		{
			Message message = new Message
			{
				Mail = createMessage.Mail,
				MessageContent = createMessage.MessageContent,
				MessageSendDate = DateTime.Now,
				NameSurname=createMessage.NameSurname,
				Phone = createMessage.Phone,
				Status=false,
				Subject=createMessage.Subject
				
			};
			_messageService.TAdd(message);
			return Ok("Mesaj  Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var values = _messageService.TGetByID(id);
			_messageService.TDelete(values);
			return Ok("Mesaj Silindi");
		}
		[HttpPut]
		public IActionResult UpdateAbout(UpdateMessageDto messageDto)
		{
			_messageService.TUpdate(new Message()
			{
				Mail=messageDto.Mail,
				MessageContent=messageDto.MessageContent,
				MessageSendDate=messageDto.MessageSendDate,
				NameSurname=messageDto.NameSurname,
				Phone=messageDto.Phone,
				Status = messageDto.Status,
				Subject=messageDto.Subject,
				MessageID = messageDto.MessageID
			});
			return Ok("Mesaj Başarıyla Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var values = _messageService.TGetByID(id);
			return Ok(values);
		}



















	}
}
