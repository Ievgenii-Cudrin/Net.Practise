using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace PhoneBook.Controllers
{
    public class AccountController : Controller
    {
        private ILogInService logInService;
        private IUserService userService;
        private IAutoMapperService autoMapperService;
        private IOperationResult operationResult;

        public AccountController(ILogInService logInService,
            IUserService userService,
            IAutoMapperService autoMapperService,
            IOperationResult operationResult)
        {
            this.logInService = logInService;
            this.userService = userService;
            this.autoMapperService = autoMapperService;
            this.operationResult = operationResult;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (this.logInService.LogIn(model.Email, model.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Email)
                    };

                    var identity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                    return RedirectToAction("Index", "PhoneBook");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = this.autoMapperService.CreateMapFromVMToDomain<RegisterModel, User>(model);
                this.operationResult = this.userService.CreateUser(user);
                if (operationResult.IsSucceed)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("", operationResult.Message);
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            this.logInService.LogOut();
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Login", "Account");
        }
    }
}
