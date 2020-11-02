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
using Microsoft.EntityFrameworkCore;

namespace Diet__Fix.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly Diet_FixContext db;

        public HomeController(SignInManager<IdentityUser> signInManager, Diet_FixContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult UserAccount()
        {
            string id = userManager.GetUserId(HttpContext.User);
            UserInfo account = db.UserInfos.Find(id);
            if (account == null)
            {
                account = new UserInfo() { UserId = id };
            }
            return View(account);
        }

        [HttpPost]
        public IActionResult UserAccount(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                if (db.UserInfos.AsNoTracking().Where(c=>c.UserId == userInfo.UserId).FirstOrDefault() != null)
                {
                    db.UserInfos.Update(userInfo);
                    db.SaveChanges();
                }
                else
                {
                    db.UserInfos.Add(userInfo);
                    db.SaveChanges();
                }
            }
            return View(userInfo);
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
