using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.AboutViewModels;
using SignalRWebUI.ViewModels.ProductViewModels;

namespace SignalRWebUI.Controllers;

public class MenuController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MenuController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }


    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7065/api/Product/get-list-products-with-category");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductViewModel>>(jsonData);

            return View(values);
        }
        return View();
    }
}