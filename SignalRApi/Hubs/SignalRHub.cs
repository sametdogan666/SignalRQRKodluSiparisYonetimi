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

    public async Task SendCategoryCount()
    {
        var resultCategoryCount = _categoryService.GetCategoryCount();
        await Clients.All.SendAsync("ReceiveCategoryCount", resultCategoryCount);
    }

    public async Task SendProductCount()
    {
        var resultProductCount = _productService.GetProductCount();
        await Clients.All.SendAsync("ReceiveProductCount", resultProductCount);
    }
}