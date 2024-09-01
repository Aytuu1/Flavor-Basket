using FloverBasketWebUI.Dtos.MailDtos;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
namespace FloverBasketWebUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(CreateMailDto createMail)
		{
			MimeMessage mimeMessage= new MimeMessage();
			MailboxAddress mailboxAddress = new MailboxAddress("Çıtır Rezervasyon", "çitirrestaurant@gmail.com");
			mimeMessage.From.Add(mailboxAddress);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User",createMail.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody=createMail.Body;
			mimeMessage.Body=bodyBuilder.ToMessageBody();
			mimeMessage.Subject=createMail.Subject;

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("çitirrestaurant@gmail.com", "hygd ebvq hhvn lqce");
			client.Send(mimeMessage);
			client.Disconnect(true);
		
			return RedirectToAction("Index", "Category");
		}
















	}
}
