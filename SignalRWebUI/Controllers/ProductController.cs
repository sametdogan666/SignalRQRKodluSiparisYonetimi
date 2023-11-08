using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.CategoryViewModels;
using SignalRWebUI.ViewModels.ProductViewModels;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SignalRWebUI.Controllers;

public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
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
            var results = JsonConvert.DeserializeObject<List<ResultProductViewModel>>(jsonData);

            return View(results);
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7065/api/Category/get-list-categories");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var results = JsonConvert.DeserializeObject<List<ResultCategoryViewModel>>(jsonData);
        List<SelectListItem> values = (from x in results
                                       select new SelectListItem
                                       {
                                           Text = x.CategoryName,
                                           Value = x.Id.ToString()
                                       }).ToList();
        ViewBag.data = values;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductViewModel createProductViewModel)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createProductViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7065/api/Product/create-product", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    public async Task<IActionResult> DeleteProduct(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7065/Product/DeleteProduct/{id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateProduct(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessageForCategory = await client.GetAsync("https://localhost:7065/api/Category/get-list-categories");
        var jsonDataForCategory = await responseMessageForCategory.Content.ReadAsStringAsync();
        var results = JsonConvert.DeserializeObject<List<ResultCategoryViewModel>>(jsonDataForCategory);
        List<SelectListItem> values = (from x in results
            select new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            }).ToList();
        ViewBag.data = values;


        //var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7065/api/Product/get-by-id-product/{id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateProductViewModel>(jsonData);

            return View(value);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductViewModel updateProductViewModel)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateProductViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7065/api/Product/update-product", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }
}