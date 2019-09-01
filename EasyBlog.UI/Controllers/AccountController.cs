using EasyBlog.BLL.Interfaces;
using EasyBlog.Domain.Entities;
using EasyBlog.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EasyBlog.UI.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var userService = HttpContext.RequestServices.GetService<IUserService>();

            var user = userService.GetUserByUsername(model.Username);

            var passwordValid = userService.VerifyPassword(user, model.Password);

            if (passwordValid)
            {
                // https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-2.2
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.UserType.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                // todo returnUrl
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }


            return View(new LoginViewModel
            {
                Username = model.Username
            });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            // todo returnUrl
            return RedirectToAction(nameof(Login));
        }
    }
}
