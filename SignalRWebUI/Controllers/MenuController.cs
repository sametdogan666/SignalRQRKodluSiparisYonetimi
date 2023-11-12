using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.AboutViewModels;
using SignalRWebUI.ViewModels.BasketViewModels;
using SignalRWebUI.ViewModels.ProductViewModels;
using System.Text;

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

    [HttpPost]
    public async Task<IActionResult> AddBasket(int id)
    {
        CreateBasketViewModel createBasketViewModel = new CreateBasketViewModel();
        createBasketViewModel.ProductId = id;
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBasketViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7065/api/Baskets/create-basket", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return Json(createBasketViewModel);
    }
}