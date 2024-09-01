using Microsoft.AspNetCore.Mvc;

namespace FloverBasketWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{

			return View();
		}
	}
}
