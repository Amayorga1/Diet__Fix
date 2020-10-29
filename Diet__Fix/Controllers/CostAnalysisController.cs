using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Diet__Fix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Diet__Fix.Controllers
{
    [Authorize]
    public class CostAnalysisController : Controller
    {
        private readonly Diet_FixContext _context;
        private readonly UserManager<IdentityUser> userManager;

        public CostAnalysisController(Diet_FixContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public IActionResult CostView()
        {
            return View();
        }
        public IActionResult DietDetails()
        {
            return View();
        }
    }
}
