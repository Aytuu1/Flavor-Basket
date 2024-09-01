using Microsoft.AspNetCore.Mvc;

namespace FloverBasketWebUI.ViewComponents.UILayoutComponents
{
  public class _UILayoutNavbarComponentPartial:ViewComponent
  {
    public IViewComponentResult Invoke()
    {
      return View();
    }
  }
}
