using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IrmaProject.ApplicationService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using IrmaProject.Models;
using IrmaProject.Common.Constant;

namespace IrmaProject.Controllers
{
    public class HomeController : Controller
    {
      private readonly IUserService _userService;

      public HomeController(IUserService userService)
      {
          _userService = userService;
      }
        public IActionResult Index()
        {
            return View();
        }

      //[HttpPost]
      //[ValidateAntiForgeryToken]
      //public IActionResult Register(RegistrationModel registrationModel)
      //{
      //  if (ModelState.IsValid)
      //  {
      //    if (registrationModel.RegirectToLogin)
      //    { 
      //        return RedirectToAction("Login");
      //    }
      //  }

      //      return View("Error");
      //  }

        //[HttpGet]
        //public IActionResult Register()
        //{
        //  ViewData["Message"] = "Your application description page.";

        //  return View();
        //}

        //[HttpGet]
        //[Route("Login/{username}")]
        //public IActionResult Login(string userName)
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Login()
        //{
        //  ViewData["Message"] = "Your contact page.";

        //  return View();
        //}


    public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
