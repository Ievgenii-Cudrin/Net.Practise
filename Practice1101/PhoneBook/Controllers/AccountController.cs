using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using AutoMapper;
using PhoneBook.WebServices;

namespace PhoneBook.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager signInManager;
        private readonly UserManager userManager;

        public AccountController(
            SignInManager signInManager,
            UserManager userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User() { Name = model.Email, Password = model.Password };

                bool successSignIn = await this.signInManager.SignInAsync(user, model.Password, isPersistent: false);

                if (successSignIn)
                {
                    return RedirectToAction("Index", "PhoneBook");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User { Name = model.Name, Password = model.Password };
            var result = this.userManager.CreateUSer(user);

            if (result)
            {
                await this.signInManager.SignInAsync(user, user.Password, isPersistent: false);
                return RedirectToAction("Index", "PhoneBook");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
