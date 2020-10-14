using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Diet__Fix.Models;

namespace Diet__Fix.Controllers
{
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
            var diet_FixContext = _context.DietType.Include(d => d.IdNavigation);
            return View(await diet_FixContext.ToListAsync());
        }

        // GET: DietTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietType = await _context.DietType
                .Include(d => d.IdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dietType == null)
            {
                return NotFound();
            }

            return View(dietType);
        }

        // GET: DietTypes/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.UserAccount, "Id", "Id");
            return View();
        }

        // POST: DietTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KetoDesc,PaleoDesc,PescDesc,MediDesc")] DietType dietType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dietType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.UserAccount, "Id", "Id", dietType.Id);
            return View(dietType);
        }

        // GET: DietTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietType = await _context.DietType.FindAsync(id);
            if (dietType == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.UserAccount, "Id", "Id", dietType.Id);
            return View(dietType);
        }

        // POST: DietTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KetoDesc,PaleoDesc,PescDesc,MediDesc")] DietType dietType)
        {
            if (id != dietType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dietType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietTypeExists(dietType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.UserAccount, "Id", "Id", dietType.Id);
            return View(dietType);
        }

        // GET: DietTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietType = await _context.DietType
                .Include(d => d.IdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dietType == null)
            {
                return NotFound();
            }

            return View(dietType);
        }

        // POST: DietTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dietType = await _context.DietType.FindAsync(id);
            _context.DietType.Remove(dietType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietTypeExists(int id)
        {
            return _context.DietType.Any(e => e.Id == id);
        }
    }
}
