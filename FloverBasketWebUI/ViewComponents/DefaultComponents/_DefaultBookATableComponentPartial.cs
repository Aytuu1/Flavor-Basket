using Microsoft.AspNetCore.Mvc;

namespace FloverBasketWebUI.ViewComponents.DefaultComponents
{
  public class _DefaultBookATableComponentPartial : ViewComponent
  {
    public IViewComponentResult Invoke()
    {
      return View();
    }
  }
}
