using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.BookingViewModel;

namespace SignalRWebUI.Controllers;

public class BookATableController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BookATableController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateBookingViewModel createBookingViewModel)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBookingViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7065/api/Booking/create-booking",stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Default");
        }

        return View();
    }
}