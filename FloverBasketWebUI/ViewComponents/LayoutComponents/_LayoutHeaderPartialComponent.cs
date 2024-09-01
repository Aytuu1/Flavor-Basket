using Microsoft.AspNetCore.Mvc;

namespace FloverBasketWebUI.ViewComponents.LayoutComponents
{
  public class _LayoutHeaderPartialComponent : ViewComponent
  {
    public IViewComponentResult Invoke()
    {

      return View();
    }
  }
}
