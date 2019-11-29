using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlayersProfile.Models;

namespace PlayersProfile.Controllers
{
    public class PlayerstabsController : Controller
    {
        private readonly playersdb1Context _context;

        public PlayerstabsController(playersdb1Context context)
        {
            _context = context;
        }

        // GET: Playerstabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Playerstab.ToListAsync());
        }

        // GET: Playerstabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerstab = await _context.Playerstab
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (playerstab == null)
            {
                return NotFound();
            }

            return View(playerstab);
        }

        // GET: Playerstabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playerstabs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,PlayerName,Country,Team")] Playerstab playerstab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerstab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playerstab);
        }

        // GET: Playerstabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerstab = await _context.Playerstab.FindAsync(id);
            if (playerstab == null)
            {
                return NotFound();
            }
            return View(playerstab);
        }

        // POST: Playerstabs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerId,PlayerName,Country,Team")] Playerstab playerstab)
        {
            if (id != playerstab.PlayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerstab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerstabExists(playerstab.PlayerId))
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
            return View(playerstab);
        }

        // GET: Playerstabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerstab = await _context.Playerstab
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (playerstab == null)
            {
                return NotFound();
            }

            return View(playerstab);
        }

        // POST: Playerstabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerstab = await _context.Playerstab.FindAsync(id);
            _context.Playerstab.Remove(playerstab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerstabExists(int id)
        {
            return _context.Playerstab.Any(e => e.PlayerId == id);
        }
    }
}
