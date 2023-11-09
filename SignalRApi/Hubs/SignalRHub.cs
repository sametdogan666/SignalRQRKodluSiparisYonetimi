using Microsoft.AspNetCore.SignalR;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Concrete;

namespace SignalRApi.Hubs;

//Hub sınıfı bir sunucu görevi görüyor. Dağıtım işlemleri buradan yapılır
public class SignalRHub : Hub
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public SignalRHub(ICategoryService categoryService, IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;
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
    }

}