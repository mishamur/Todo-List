using AuntificationMetanit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AuntificationMetanit.Controllers
{
    public class HomeController : Controller
    {
       
        [Authorize]
        public IActionResult Index()
        {
            return Content(User.Identity.Name);
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
