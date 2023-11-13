using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.Entities.Entities;
using SignalRWebUI.ViewModels.IdentityViewModels;

namespace SignalRWebUI.Controllers;

public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
    {
        var appUser = new AppUser()
        {
            FirstName = registerViewModel.FirstName,
            LastName = registerViewModel.LastName,
            Email = registerViewModel.Email,
            UserName = registerViewModel.UserName
        };

        var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Login");
        }

        return View();
    }
}