using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using moha.Data;
using moha.Models;

namespace moha.Controllers
{
    public class ParticipentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Participents
        public async Task<IActionResult> Index()
        {
              return _context.participents != null ? 
                          View(await _context.participents.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.participents'  is null.");
        }

        // GET: Participents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.participents == null)
            {
                return NotFound();
            }

            var participent = await _context.participents
                .FirstOrDefaultAsync(m => m.ParticipentId == id);
            if (participent == null)
            {
                return NotFound();
            }

            return View(participent);
        }

        // GET: Participents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Participents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParticipentId,name,Description,Roles")] Participent participent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(participent);
        }

        // GET: Participents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.participents == null)
            {
                return NotFound();
            }

            var participent = await _context.participents.FindAsync(id);
            if (participent == null)
            {
                return NotFound();
            }
            return View(participent);
        }

        // POST: Participents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParticipentId,name,Description,Roles")] Participent participent)
        {
            if (id != participent.ParticipentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipentExists(participent.ParticipentId))
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
            return View(participent);
        }

        // GET: Participents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.participents == null)
            {
                return NotFound();
            }

            var participent = await _context.participents
                .FirstOrDefaultAsync(m => m.ParticipentId == id);
            if (participent == null)
            {
                return NotFound();
            }

            return View(participent);
        }

        // POST: Participents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.participents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.participents'  is null.");
            }
            var participent = await _context.participents.FindAsync(id);
            if (participent != null)
            {
                _context.participents.Remove(participent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipentExists(int id)
        {
          return (_context.participents?.Any(e => e.ParticipentId == id)).GetValueOrDefault();
        }
    }
}
