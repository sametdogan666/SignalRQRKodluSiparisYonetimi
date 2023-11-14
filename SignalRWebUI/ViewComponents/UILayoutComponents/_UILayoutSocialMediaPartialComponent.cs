using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.SocialMediaViewModels;

namespace SignalRWebUI.ViewComponents.UILayoutComponents;

public class _UILayoutSocialMediaPartialComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _UILayoutSocialMediaPartialComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7065/api/SocialMedia/get-list-social-medias");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSocialMediaViewModel>>(jsonData);

            return View(values);
        }

        return View();
    }
}