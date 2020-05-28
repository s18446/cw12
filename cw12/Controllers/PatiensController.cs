using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cw12.Models;

namespace cw12.Controllers
{
    public class PatiensController : Controller
    {
        private readonly s18446Context _context;

        public PatiensController(s18446Context context)
        {
            _context = context;
        }

        // GET: Patiens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patiens.ToListAsync());
        }

        // GET: Patiens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patiens = await _context.Patiens
                .FirstOrDefaultAsync(m => m.IdPatient == id);
            if (patiens == null)
            {
                return NotFound();
            }

            return View(patiens);
        }

        // GET: Patiens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPatient,FirstName,LastName,BirthDate")] Patiens patiens)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patiens);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patiens);
        }

        // GET: Patiens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patiens = await _context.Patiens.FindAsync(id);
            if (patiens == null)
            {
                return NotFound();
            }
            return View(patiens);
        }

        // POST: Patiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPatient,FirstName,LastName,BirthDate")] Patiens patiens)
        {
            if (id != patiens.IdPatient)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patiens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatiensExists(patiens.IdPatient))
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
            return View(patiens);
        }

        // GET: Patiens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patiens = await _context.Patiens
                .FirstOrDefaultAsync(m => m.IdPatient == id);
            if (patiens == null)
            {
                return NotFound();
            }

            return View(patiens);
        }

        // POST: Patiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patiens = await _context.Patiens.FindAsync(id);
            _context.Patiens.Remove(patiens);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatiensExists(int id)
        {
            return _context.Patiens.Any(e => e.IdPatient == id);
        }
    }
}
