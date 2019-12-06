using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlayersProfile.Models;

namespace PlayersProfile.Controllers
{

    
    public class CarstabsController : Controller
    {
        private readonly playersdb1Context _context;

        public CarstabsController(playersdb1Context context)
        {
            _context = context;
        }

        

        // GET: Carstabs

        public async Task<IActionResult> Index()
        {
            var playersdb1Context = _context.Carstab.Include(c => c.Player);
            return View(await playersdb1Context.ToListAsync());
        }

        // GET: Carstabs/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carstab = await _context.Carstab
                .Include(c => c.Player)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (carstab == null)
            {
                return NotFound();
            }

            return View(carstab);
        }

        // GET: Carstabs/Create
        //[Authorize]
        public IActionResult Create()
        {

            if (User.Identity.IsAuthenticated)
            {

                ViewData["PlayerId"] = new SelectList(_context.Playerstab, "PlayerId", "PlayerId");
                return View();

            }

            else { return Redirect("~/Identity/Account/Login"); }

        }

        // POST: Carstabs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("CarId,Cost,Brand,Year,PlayerId")] Carstab carstab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carstab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Playerstab, "PlayerId", "PlayerId", carstab.PlayerId);
            return View(carstab);
        }

        // GET: Carstabs/Edit/5
        
        public async Task<IActionResult> Edit(int? id)
        {

            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var carstab = await _context.Carstab.FindAsync(id);
                if (carstab == null)
                {
                    return NotFound();
                }
                ViewData["PlayerId"] = new SelectList(_context.Playerstab, "PlayerId", "PlayerId", carstab.PlayerId);
                return View(carstab);
            }

            else { return Redirect("~/Identity/Account/Login"); }


        }

        // POST: Carstabs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("CarId,Cost,Brand,Year,PlayerId")] Carstab carstab)
        {
            if (id != carstab.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carstab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarstabExists(carstab.CarId))
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
            ViewData["PlayerId"] = new SelectList(_context.Playerstab, "PlayerId", "PlayerId", carstab.PlayerId);
            return View(carstab);
        }

        // GET: Carstabs/Delete/5

         
        public async Task<IActionResult> Delete(int? id)
        {

            if (User.Identity.IsAuthenticated)
            {

                if (id == null)
                {
                    return NotFound();
                }

                var carstab = await _context.Carstab
                    .Include(c => c.Player)
                    .FirstOrDefaultAsync(m => m.CarId == id);
                if (carstab == null)
                {
                    return NotFound();
                }

                return View(carstab);

            }

            else { return Redirect("~/Identity/Account/Login"); }

        }

        // POST: Carstabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carstab = await _context.Carstab.FindAsync(id);
            _context.Carstab.Remove(carstab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarstabExists(int id)
        {
            return _context.Carstab.Any(e => e.CarId == id);
        }
    }
}
