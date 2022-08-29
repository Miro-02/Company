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
    public class TeamLeadsController : Controller
    {
        private readonly CompanyNemetschekContext _context;

        public TeamLeadsController(CompanyNemetschekContext context)
        {
            _context = context;
        }

        // GET: TeamLeads
        public async Task<IActionResult> Index()
        {
              return _context.TeamLead != null ? 
                          View(await _context.TeamLead.ToListAsync()) :
                          Problem("Entity set 'CompanyNemetschekContext.TeamLead'  is null.");
        }

        // GET: TeamLeads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeamLead == null)
            {
                return NotFound();
            }

            var teamLead = await _context.TeamLead
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teamLead == null)
            {
                return NotFound();
            }

            return View(teamLead);
        }

        // GET: TeamLeads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamLeads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MFirstName,MLastName,MEmail,MStartingDate,MPosition,MAdress,ID,MSalary")] TeamLead teamLead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamLead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamLead);
        }

        // GET: TeamLeads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeamLead == null)
            {
                return NotFound();
            }

            var teamLead = await _context.TeamLead.FindAsync(id);
            if (teamLead == null)
            {
                return NotFound();
            }
            return View(teamLead);
        }

        // POST: TeamLeads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MFirstName,MLastName,MEmail,MStartingDate,MPosition,MAdress,ID,MSalary")] TeamLead teamLead)
        {
            if (id != teamLead.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamLead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamLeadExists(teamLead.ID))
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
            return View(teamLead);
        }

        // GET: TeamLeads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeamLead == null)
            {
                return NotFound();
            }

            var teamLead = await _context.TeamLead
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teamLead == null)
            {
                return NotFound();
            }

            return View(teamLead);
        }

        // POST: TeamLeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeamLead == null)
            {
                return Problem("Entity set 'CompanyNemetschekContext.TeamLead'  is null.");
            }
            var teamLead = await _context.TeamLead.FindAsync(id);
            if (teamLead != null)
            {
                _context.TeamLead.Remove(teamLead);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamLeadExists(int id)
        {
          return (_context.TeamLead?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
