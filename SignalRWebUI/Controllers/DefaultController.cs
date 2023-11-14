using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.MessageViewModels;

namespace SignalRWebUI.Controllers;

public class DefaultController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DefaultController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public PartialViewResult SendMessage()
    {
        return PartialView();
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(CreateMessageViewModel createMessageViewModel)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createMessageViewModel);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7065/api/Messages/create-message", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();

    }
}