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
    public class DietTypesController : Controller
    {
        private readonly Diet_FixContext _context;

        public DietTypesController(Diet_FixContext context)
        {
            _context = context;
        }

        // GET: DietTypes
        public async Task<IActionResult> Index()
        {
            return View();
        }
        
        public IActionResult KetoDiet()
        {
            return View();
        }

        public IActionResult PaleoDiet()
        {
            return View();
        }

        public IActionResult MediDiet()
        {
            return View();
        }

        public IActionResult IntermDiet()
        {
            return View();
        }
    }
}
