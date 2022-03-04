﻿using Entities;
using K205Oleev.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace K205Oleev.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<K205User> _userManager;
        private readonly SignInManager<K205User> _signInManager;
        public AuthController(UserManager<K205User> userManager, SignInManager<K205User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            K205User user = new()
            {
                UserName = registerVM.Name,
                Name = registerVM.Name,
                Surname = registerVM.Name,
                Email = registerVM.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user,registerVM.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
