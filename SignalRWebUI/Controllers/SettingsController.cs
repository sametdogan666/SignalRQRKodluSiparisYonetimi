using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.Entities.Entities;
using SignalRWebUI.ViewModels.IdentityViewModels;

namespace SignalRWebUI.Controllers;

public class SettingsController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public SettingsController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var value = await _userManager.FindByNameAsync(User.Identity?.Name);
        UserEditViewModel userEditViewModel = new UserEditViewModel
        {
            FirstName = value.FirstName,
            LastName = value.LastName,
            UserName = value.UserName,
            Email = value.Email
        };

        return View(userEditViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
    {
        if (userEditViewModel.Password == userEditViewModel.ConfirmPassword)
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            user.FirstName = userEditViewModel.FirstName;
            user.LastName = userEditViewModel.LastName;
            user.UserName = userEditViewModel.UserName;
            user.Email = userEditViewModel.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Login");
        }

        return View();
    }
}