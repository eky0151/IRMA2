using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IrmaProject.Models;

namespace IrmaProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegistrationModel registrationModel)
        {
          if (ModelState.IsValid)
          {
            if (registrationModel.RegirectToLogin)
              return RedirectToAction("Login", new { registrationModel.UserName });
          }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
          ViewData["Message"] = "Your application description page.";

          return View();
        }

        [HttpGet]
        [Route("Login/{username}")]
        public IActionResult Login(string userName)
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
          ViewData["Message"] = "Your contact page.";

          return View();
        }


    public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
