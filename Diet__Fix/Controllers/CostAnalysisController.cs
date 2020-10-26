using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Diet__Fix.Models;
using Microsoft.AspNetCore.Authorization;

namespace Diet__Fix.Controllers
{
    [Authorize]
    public class CostAnalysisController : Controller
    {
        private readonly Diet_FixContext _context;

        public CostAnalysisController(Diet_FixContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
