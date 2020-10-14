using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Diet__Fix.Models;

namespace Diet__Fix.Controllers
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

        public IActionResult Index2()
        {
            // populate data model...
            DietType MyViewModel = new DietType()
            {
                Id = 2,
                KetoDesc = "something",
                PaleoDesc = "something else"
            };
            return View("Index2", MyViewModel);
        }

    }
}
