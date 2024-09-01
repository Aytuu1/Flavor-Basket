using Microsoft.AspNetCore.Mvc;

namespace FloverBasketWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutFooterComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{

			return View();
		}
	}
}
