using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.CategoryViewModels;
using System.Text;
using SignalRWebUI.ViewModels.FeatureViewModels;

namespace SignalRWebUI.Controllers;

public class FeatureController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FeatureController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7065/api/Feature/get-list-features");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<ResultFeatureViewModel>>(jsonData);

            return View(results);
        }

        return View();
    }

    [HttpGet]
    public IActionResult CreateFeature()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureViewModel createFeatureViewModel)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createFeatureViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7065/api/Feature/create-feature", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    public async Task<IActionResult> DeleteFeature(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7065/api/Feature/delete-feature/{id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateFeature(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7065/api/Feature/get-by-id-feature/{id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateFeatureViewModel>(jsonData);

            return View(value);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureViewModel updateFeatureViewModel)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateFeatureViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7065/api/Feature/update-feature", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }
}