using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.CategoryViewModels;
using System.Text;
using SignalRWebUI.ViewModels.DiscountViewModel;

namespace SignalRWebUI.Controllers;

public class DiscountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DiscountController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7065/api/Discount/get-list-discounts");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<ResultDiscountViewModel>>(jsonData);

            return View(results);
        }

        return View();
    }

    [HttpGet]
    public IActionResult CreateDiscount()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiscount(CreateDiscountViewModel createDiscountViewModel)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createDiscountViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7065/api/Discount/create-discount", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    public async Task<IActionResult> DeleteDiscount(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7065/api/Discount/delete-discount/{id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateDiscount(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7065/api/Discount/get-by-id-discount/{id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateDiscountViewModel>(jsonData);

            return View(value);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateDiscount(UpdateDiscountViewModel updateDiscountViewModel)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateDiscountViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7065/api/Discount/update-discount", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }
}