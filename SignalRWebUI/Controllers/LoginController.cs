﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.Entities.Entities;
using SignalRWebUI.ViewModels.IdentityViewModels;

namespace SignalRWebUI.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel loginViewModel)
    {
        var result =
            await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Category");
        }

        return View();
    }
}