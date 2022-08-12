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
    public class MosquesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MosquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mosques
        public async Task<IActionResult> Index()
        {
              return _context.mosques != null ? 
                          View(await _context.mosques.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.mosques'  is null.");
        }

        // GET: Mosques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.mosques == null)
            {
                return NotFound();
            }

            var mosque = await _context.mosques.Include(x=>x.Participents) .FirstOrDefaultAsync(m => m.mosqueId == id);
               
            if (mosque == null)
            {
                return NotFound();
            }

            return View(mosque);
        }

        // GET: Mosques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mosques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Location,Info")] Mosque mosque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mosque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mosque);
        }

        // GET: Mosques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.mosques == null)
            {
                return NotFound();
            }

            var mosque = await _context.mosques.FindAsync(id);
            if (mosque == null)
            {
                return NotFound();
            }
            return View(mosque);
        }

        // POST: Mosques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mosqueId,Name,Location,Info")] Mosque mosque)
        {
            if (id != mosque.mosqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mosque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MosqueExists(mosque.mosqueId))
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
            return View(mosque);
        }

        // GET: Mosques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.mosques == null)
            {
                return NotFound();
            }

            var mosque = await _context.mosques
                .FirstOrDefaultAsync(m => m.mosqueId == id);
            if (mosque == null)
            {
                return NotFound();
            }

            return View(mosque);
        }

        // POST: Mosques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.mosques == null)
            {
                return Problem("Entity set 'ApplicationDbContext.mosques'  is null.");
            }
            var mosque = await _context.mosques.FindAsync(id);
            if (mosque != null)
            {
                _context.mosques.Remove(mosque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MosqueExists(int id)
        {
          return (_context.mosques?.Any(e => e.mosqueId == id)).GetValueOrDefault();
        }
    }
}
