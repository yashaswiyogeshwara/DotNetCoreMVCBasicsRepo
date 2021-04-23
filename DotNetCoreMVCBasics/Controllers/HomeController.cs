using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetCoreMVCBasics.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace DotNetCoreMVCBasics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret() {
            return View();
        }

        public IActionResult Authenticate()
        {
            List<Claim> someClaims = new List<Claim>() {
                new Claim(ClaimTypes.Name,"Yash"),
                new Claim(ClaimTypes.Email, "Yash.yoges@gmail.com")
                };
            ClaimsIdentity identity = new ClaimsIdentity(someClaims, "CookieAuth");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(principal);
            return RedirectToAction("Index");
        }

    }
}
