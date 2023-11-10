using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}