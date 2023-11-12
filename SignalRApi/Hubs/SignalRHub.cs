using Microsoft.AspNetCore.SignalR;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Concrete;

namespace SignalRApi.Hubs;

//Hub sınıfı bir sunucu görevi görüyor. Dağıtım işlemleri buradan yapılır
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

    public async Task SendStatistics()
    {
        var resultCategoryCount = _categoryService.GetCategoryCount();
        await Clients.All.SendAsync("ReceiveCategoryCount", resultCategoryCount);

        var resultProductCount = _productService.GetProductCount();
        await Clients.All.SendAsync("ReceiveProductCount", resultProductCount);

        var resultActiveCategoryCount = _categoryService.GetActiveCategoryCount();
        await Clients.All.SendAsync("ReceiveActiveCategoryCount", resultActiveCategoryCount);

        var resultPassiveCategoryCount = _categoryService.GetPassiveCategoryCount();
        await Clients.All.SendAsync("ReceivePassiveCategoryCount", resultPassiveCategoryCount);

        var resultProductCountByCategoryNameHamburger = _productService.GetProductCountByCategoryNameHamburger();
        await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", resultProductCountByCategoryNameHamburger);

        var resultProductCountByCategoryNameDrink = _productService.GetProductCountByCategoryNameDrink();
        await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", resultProductCountByCategoryNameDrink);

        var resultProductPriceAvg = _productService.GetProductPriceAvg();
        await Clients.All.SendAsync("ReceiveProductPriceAvg", resultProductPriceAvg.ToString("0.00") + "₺");

        var resultProductNameByMaxPrice = _productService.GetProductNameByMaxPrice();
        await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", resultProductNameByMaxPrice);

        var resultProductNameByMinPrice = _productService.GetProductNameByMinPrice();
        await Clients.All.SendAsync("ReceiveProductNameByMinPrice", resultProductNameByMinPrice);

        var resultProductPriceByHamburgerAvg = _productService.GetProductPriceByHamburgerAvg();
        await Clients.All.SendAsync("ReceiveProductPriceByHamburgerAvg", resultProductPriceByHamburgerAvg.ToString("0.00") + "₺");

        var resultTotalOrderCount = _orderService.GetTotalOrderCount();
        await Clients.All.SendAsync("ReceiveTotalOrderCount", resultTotalOrderCount);

        var resultActiveOrderCount = _orderService.GetActiveOrderCount();
        await Clients.All.SendAsync("ReceiveActiveOrderCount", resultActiveOrderCount);

        var resultLastOrderPrice = _orderService.GetLastOrderPrice();
        await Clients.All.SendAsync("ReceiveLastOrderPrice", resultLastOrderPrice.ToString("0.00") + "₺");

        var resultTotalMoneyCaseAmount = _moneyCaseService.GetTotalMoneyCaseAmount();
        await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", resultTotalMoneyCaseAmount.ToString("0.00") + "₺");

        //var resultTodayTotalPrice = _orderService.GeTodayTotalPrice();
        //await Clients.All.SendAsync("ReceiveTodayTotalPrice", resultTodayTotalPrice);

        var resultMenuTableCount = _menuTableService.GetMenuTableCount();
        await Clients.All.SendAsync("ReceiveMenuTableCount", resultMenuTableCount);
    }

    public async Task SendProgress()
    {
        var resultTotalMoneyCaseAmount = _moneyCaseService.GetTotalMoneyCaseAmount();
        await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", resultTotalMoneyCaseAmount.ToString("0.00") + "₺");

        var resultActiveOrderCount = _orderService.GetActiveOrderCount();
        await Clients.All.SendAsync("ReceiveActiveOrderCount", resultActiveOrderCount);

        var resultMenuTableCount = _menuTableService.GetMenuTableCount();
        await Clients.All.SendAsync("ReceiveMenuTableCount", resultMenuTableCount);
    }

    public async Task GetBookingList()
    {
        var resultBookingList = _bookingService.GetAll();
        await Clients.All.SendAsync("ReceiveBookingList", resultBookingList);
    }

    public async Task SendNotification()
    {
        var resultNotificationCountByFalse = _notificationService.GetNotificationCountByStatusFalse();
        await Clients.All.SendAsync("ReceiveNotificationCountByFalse", resultNotificationCountByFalse);

        var resultNotificationListByFalse = _notificationService.GetAllNotificationByFalse();
        await Clients.All.SendAsync("ReceiveNotificationListByFalse", resultNotificationListByFalse);
    }

    public async Task GetMenuTableStatus()
    {
        var resultMenuTableStatus = _menuTableService.GetAll();
        await Clients.All.SendAsync("ReceiveMenuTableStatus", resultMenuTableStatus);
    }
}