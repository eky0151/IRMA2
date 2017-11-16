using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using IrmaProject.ApplicationService.Interfaces;
using IrmaProject.Repository.EntityFramework.Interfaces;

namespace IrmaProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserRepository userRepository;

        public AccountController(IUserService userService, IUserRepository userRepository)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult LoginFacebook()
        {
            var auth = new AuthenticationProperties { RedirectUri = Url.Action("AuthCallback", "Account") };
            return Challenge(auth, "Facebook");
        }

        public IActionResult LoginGoogle()
        {
            var auth = new AuthenticationProperties { RedirectUri = Url.Action("AuthCallback", "Account") };
            return Challenge(auth, "Google");
        }

        public async Task<IActionResult> AuthCallback()
        {
            var fbIdentity = User.Identities.FirstOrDefault(i => i.AuthenticationType == "Facebook" && i.IsAuthenticated);
            var googleIdentity = User.Identities.FirstOrDefault(i => i.AuthenticationType == "Google" && i.IsAuthenticated);
            if (fbIdentity == null && googleIdentity == null)
            {
                return Redirect(Url.Action("Login", "Account"));
            }
            if(fbIdentity != null)
            {
                await userService.EnsureUser(fbIdentity.Claims.ToList());
            }
            if(googleIdentity != null)
            {
                await userService.EnsureUser(googleIdentity.Claims.ToList());
            }
            return Redirect(Url.Action("Index", "Home"));
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}