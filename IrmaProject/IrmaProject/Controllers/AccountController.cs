using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using IrmaProject.ApplicationService.Interfaces;

namespace IrmaProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult LoginFacebook()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = Url.Action("FacebookLoginCallback", "Account") });
        }

        public async Task<IActionResult> FacebookLoginCallback()
        {
            var identity = User.Identities.FirstOrDefault(i => i.AuthenticationType == "Facebook" && i.IsAuthenticated);
            if (identity == null)
                return Redirect(Url.Action("Login", "Account"));
            await userService.EnsureUser(identity.Claims.ToList());
            return Redirect(Url.Action("Index", "Home"));
        }

        public async Task<IActionResult> Test()
        {
            var temp = HttpContext.Authentication;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}