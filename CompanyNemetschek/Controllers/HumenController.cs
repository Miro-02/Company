using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyNemetschek.Data;
using CompanyNemetschek.Models;

namespace CompanyNemetschek.Controllers
{
    public class HumenController : Controller
    {
        private readonly CompanyNemetschekContext _context;

        public HumenController(CompanyNemetschekContext context)
        {
            _context = context;
        }

        // GET: Humen
        public async Task<IActionResult> Index()
        {
              return _context.Human != null ? 
                          View(await _context.Human.ToListAsync()) :
                          Problem("Entity set 'CompanyNemetschekContext.Human'  is null.");
        }

        // GET: Humen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Human == null)
            {
                return NotFound();
            }

            var human = await _context.Human
                .FirstOrDefaultAsync(m => m.ID == id);
            if (human == null)
            {
                return NotFound();
            }

            return View(human);
        }

        // GET: Humen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Humen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MFirstName,MLastName,MEmail,MStartingDate,MPosition,MAdress,ID,MSalary")] Human human)
        {
            if (ModelState.IsValid)
            {
                _context.Add(human);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(human);
        }

        // GET: Humen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Human == null)
            {
                return NotFound();
            }

            var human = await _context.Human.FindAsync(id);
            if (human == null)
            {
                return NotFound();
            }
            return View(human);
        }

        // POST: Humen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MFirstName,MLastName,MEmail,MStartingDate,MPosition,MAdress,ID,MSalary")] Human human)
        {
            if (id != human.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(human);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HumanExists(human.ID))
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
            return View(human);
        }

        // GET: Humen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Human == null)
            {
                return NotFound();
            }

            var human = await _context.Human
                .FirstOrDefaultAsync(m => m.ID == id);
            if (human == null)
            {
                return NotFound();
            }

            return View(human);
        }

        // POST: Humen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Human == null)
            {
                return Problem("Entity set 'CompanyNemetschekContext.Human'  is null.");
            }
            var human = await _context.Human.FindAsync(id);
            if (human != null)
            {
                _context.Human.Remove(human);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HumanExists(int id)
        {
          return (_context.Human?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
