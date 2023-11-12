using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.AboutViewModels;
using SignalRWebUI.ViewModels.BasketViewModels;
using System.Text;

namespace SignalRWebUI.Controllers;

public class BasketsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BasketsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7065/api/Baskets/get-basket-list-by-menu-table-with-product-name/4");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBasketWithProductViewModel>>(jsonData);

            return View(values);
        }
        return View();
    }

    
}