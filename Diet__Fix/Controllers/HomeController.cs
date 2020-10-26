using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Diet__Fix.Models;
using Diet__Fix.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;

namespace Diet__Fix.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(HttpContext.User))
            {
                return RedirectToAction("Index", "DietTypes");
            }
            else
            {
                return LocalRedirect("/Identity/Account/Login");
            }
        }
    }
}
