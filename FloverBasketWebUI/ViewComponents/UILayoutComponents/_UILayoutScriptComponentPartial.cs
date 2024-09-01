using Microsoft.AspNetCore.Mvc;

namespace FloverBasketWebUI.ViewComponents.UILayoutComponents
{
  public class _UILayoutScriptComponentPartial:ViewComponent
  {
    public IViewComponentResult Invoke()
    {
      return View();
    }
  }
}
