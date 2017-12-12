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


    public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
