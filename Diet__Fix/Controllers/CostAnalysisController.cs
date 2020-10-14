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
    public class CostAnalysisController : Controller
    {
        private readonly Diet_FixContext _context;

        public CostAnalysisController(Diet_FixContext context)
        {
            _context = context;
        }

        // GET: CostAnalysis
        public async Task<IActionResult> Index()
        {
            var diet_FixContext = _context.CostAnalysis.Include(c => c.IdNavigation);
            return View(await diet_FixContext.ToListAsync());
        }

        // GET: CostAnalysis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costAnalysis = await _context.CostAnalysis
                .Include(c => c.IdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costAnalysis == null)
            {
                return NotFound();
            }

            return View(costAnalysis);
        }

        // GET: CostAnalysis/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.UserAccount, "Id", "Id");
            return View();
        }

        // POST: CostAnalysis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CostOptions,PastCost,CurrentCost,CostComparison")] CostAnalysis costAnalysis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costAnalysis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.UserAccount, "Id", "Id", costAnalysis.Id);
            return View(costAnalysis);
        }

        // GET: CostAnalysis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costAnalysis = await _context.CostAnalysis.FindAsync(id);
            if (costAnalysis == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.UserAccount, "Id", "Id", costAnalysis.Id);
            return View(costAnalysis);
        }

        // POST: CostAnalysis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CostOptions,PastCost,CurrentCost,CostComparison")] CostAnalysis costAnalysis)
        {
            if (id != costAnalysis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costAnalysis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostAnalysisExists(costAnalysis.Id))
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
            ViewData["Id"] = new SelectList(_context.UserAccount, "Id", "Id", costAnalysis.Id);
            return View(costAnalysis);
        }

        // GET: CostAnalysis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costAnalysis = await _context.CostAnalysis
                .Include(c => c.IdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costAnalysis == null)
            {
                return NotFound();
            }

            return View(costAnalysis);
        }

        // POST: CostAnalysis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costAnalysis = await _context.CostAnalysis.FindAsync(id);
            _context.CostAnalysis.Remove(costAnalysis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostAnalysisExists(int id)
        {
            return _context.CostAnalysis.Any(e => e.Id == id);
        }
    }
}
