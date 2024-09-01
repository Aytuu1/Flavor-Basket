using FlavorB.BusinessLayer.Abstract;
using FlavorB.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;

namespace FlavorBasketAPI.Hubs
{
  public class SignalRHub : Hub
  {
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;
    private readonly IMoneyCaseService _moneyCaseService;
    private readonly IMenuTableService _menuTableService;
    private readonly IBookingService _bookingService;
    private readonly INotificationService _notificationService;

    public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
    {
      _categoryService = categoryService;
      _productService = productService;
      _orderService = orderService;
      _moneyCaseService = moneyCaseService;
      _menuTableService = menuTableService;
      _bookingService = bookingService;
      _notificationService = notificationService;
    }
    public static int clientCount { get; set; } = 0;
    public async Task SendStatistic()
    {
      var value = _categoryService.TCategoryCount(); // kategori sayısını alıyoruz değişkene
      await Clients.All.SendAsync("ReceiveCategoryCount", value);         // kategori sayısını cliente yolluyoruz

      var activeCategory = _categoryService.TActiveCategoryCount();
      await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategory);

      var passiveCategory = _categoryService.TPassiveCategoryCount();
      await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategory);

      var value2 = _productService.TProductCount();
      await Clients.All.SendAsync("ReceiveProductCount", value2);

      var categoryHamburger = _productService.TProductCountByCategoryNameHamburger();
      await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", categoryHamburger);

      var categoryDrink = _productService.TProductCountByCategoryNameDrink();
      await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", categoryDrink);

      var avgPrice = _productService.TProductPriceAvg();
      await Clients.All.SendAsync("ReceiveAvgPrice", avgPrice.ToString("0.00") + " ₺");

      var maxPriceName = _productService.TProductNameByMaxPrice();
      await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", maxPriceName);

      var minPriceName = _productService.TProductNameByMinPrice();
      await Clients.All.SendAsync("ReceiveProductNameByMinPrice", minPriceName);

      var avgHamburgerPrice = _productService.TProductPriceByHamburger();
      await Clients.All.SendAsync("ReceiveProductPriceByHamburger", avgHamburgerPrice.ToString("0.00") + " ₺");

      var orderCount = _orderService.TTotalOrderCount();
      await Clients.All.SendAsync("ReceiveTotalOrderCount", orderCount);

      var activeOrderCount = _orderService.TActiveOrderCount();
      await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

      var lastorderPrice = _orderService.TLastOrderPrice();
      await Clients.All.SendAsync("ReceiveLastOrderPrice", lastorderPrice.ToString("0.00") + " ₺");

      var moneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount();
      await Clients.All.SendAsync("ReceivemoneyCaseAmount", moneyCaseAmount.ToString("0.00") + " ₺");

      var tableCount = _menuTableService.TMenuTableCount();
      await Clients.All.SendAsync("ReceiveMenuTableCount", tableCount);
    }
    public async Task SendProgress()
    {
      var totalMoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount();
      await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneyCaseAmount.ToString("0.00") + "₺");

      var activeOrderCount = _orderService.TActiveOrderCount();
      await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

      var tableCount = _menuTableService.TMenuTableCount();
      await Clients.All.SendAsync("ReceiveMenuTableCount", tableCount);

      var productPriceAvg = _productService.TProductPriceAvg();
      await Clients.All.SendAsync("ReceiveProductPriceAvg", productPriceAvg);

      var productPriceByHamburger = _productService.TProductPriceByHamburger();
      await Clients.All.SendAsync("ReceivePriceByHamburger", productPriceByHamburger);

      var countByCategoryNameDrink = _productService.TProductCountByCategoryNameDrink();
      await Clients.All.SendAsync("ReceiveCountByCategoryNameDrink", countByCategoryNameDrink);

    }
    public async Task GetBookingList()
    {
      var getbookingList = _bookingService.TGetAll();
      await Clients.All.SendAsync("ReceiveBookingList", getbookingList);
    }
    public async Task SendNotification()
    {
      var notificationFalse = _notificationService.TNotificationCountByStatusFalse();
      await Clients.All.SendAsync("ReceiveNotificationStatusFalse", notificationFalse);

      var notificationListByFalse = _notificationService.TGetAllNotificationByFalse();
      await Clients.All.SendAsync("ReceiveGetAllNotificationByFalse", notificationListByFalse);
    }
    public async Task GetMenuTableStatus()
    {
      var menuTableStatus = _menuTableService.TGetAll();
      await Clients.All.SendAsync("ReceiveMenuTableStatus", menuTableStatus);
    }
    public async Task SendMessage(string user, string message)
    {
      await Clients.All.SendAsync("ReceiveMessage", user, message);

    }
    public override async Task OnConnectedAsync()
    {
      clientCount++;
      await Clients.All.SendAsync("ReceiveClientCount", clientCount);
      await base.OnConnectedAsync();
    }
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
      clientCount--;
      await Clients.All.SendAsync("ReceiveClientCount", clientCount);
      await base.OnDisconnectedAsync(exception);
    }







  }
}
