using Microsoft.AspNetCore.Mvc;

namespace FloverBasketWebUI.ViewComponents.UILayoutComponents
{
  public class _UILayoutHeadComponentPartial:ViewComponent
  {
    public IViewComponentResult Invoke()
    {
      return View();
    }
  }
}
