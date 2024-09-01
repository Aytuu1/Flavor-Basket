using Microsoft.AspNetCore.Mvc;

namespace FloverBasketWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{

			return View();
		}
	}
}
